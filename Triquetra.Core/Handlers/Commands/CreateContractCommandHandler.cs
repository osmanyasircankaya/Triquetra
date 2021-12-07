using FluentValidation;
using MediatR;
using Triquetra.Core.Exceptions;
using Triquetra.Domain.Data;
using Triquetra.Domain.Data.Entities;
using Triquetra.Domain.DTO.Contracts;

namespace Triquetra.Core.Handlers.Commands
{
    public class CreateContractCommand : IRequest<int>
    {
        public CreateContractDTO Model { get; }

        public CreateContractCommand(CreateContractDTO model)
        {
            this.Model = model;
        }
    }

    public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<CreateContractDTO> _validator;

        public CreateContractCommandHandler(IUnitOfWork repository, IValidator<CreateContractDTO> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<int> Handle(CreateContractCommand request, CancellationToken cancellationToken)
        {
            CreateContractDTO model = request.Model;

            var result = _validator.Validate(model);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }

            var entity = new Contract
            {
                PanelPower = model.Power * 1.2,
                Power = model.Power,
                RoofSize = ((model.Power * 1.2) / 450) * 2.5
            };

            _repository.Contracts.Add(entity);
            await _repository.CommitAsync();

            var materials = _repository.Materials.GetAll();
            materials = materials.Where(s => s.IsActive).OrderBy(s => s.Id);

            foreach (var material in materials)
            {
                if (material.HasDefaultPrice)
                {
                    if (material.IsUnique && material.HasDefaultPrice)
                    {
                        var contractMaterial = new ContractMaterial()
                        {
                            ContractId = entity.Id,
                            MaterialId = material.Id,
                            Price = material.Price,
                            Cost = material.Cost,
                            Quantity = 1
                        };
                        _repository.ContractMaterials.Add(contractMaterial);
                    }
                    else
                    {
                        var contractMaterial = new ContractMaterial()
                        {
                            ContractId = entity.Id,
                            MaterialId = material.Id,
                        };
                        switch (material.Id)
                        {
                            case 2:
                                //450W Monoperc Solar Panel
                                contractMaterial.Quantity = (int?) Math.Ceiling(entity.PanelPower / 450);
                                contractMaterial.Price = contractMaterial.Quantity * material.Price;
                                contractMaterial.Cost = contractMaterial.Quantity * material.Cost;
                                break;
                            case 3:
                                //Konstrüksiyon panel başına-ÇATI SİSTEMİ
                                contractMaterial.Quantity = ((int?) Math.Ceiling(entity.PanelPower / 450));
                                contractMaterial.Price = contractMaterial.Quantity * material.Price;
                                contractMaterial.Cost = contractMaterial.Quantity * material.Cost;
                                break;
                            case 8:
                                //45 KW INVERTER-HUAWEI SUN2000-45 KTL M0 / 45kW
                                contractMaterial.Quantity = 1;
                                contractMaterial.Price = contractMaterial.Quantity * material.Price;
                                contractMaterial.Cost = contractMaterial.Quantity * material.Cost;
                                break;
                            case 14:
                                //Solar Kablo - Kırmızı/Siyah- 6mm (1X6MM SOLAR KABLO)
                                contractMaterial.Quantity = (int?) ((entity.PanelPower / 450) * 9.8);
                                contractMaterial.Price = contractMaterial.Quantity * material.Price;
                                contractMaterial.Cost = contractMaterial.Quantity * material.Cost;
                                break;
                            case 15:
                                //Solar Konnektör
                                contractMaterial.Quantity = (int?) Math.Ceiling((entity.PanelPower / 450) / 16);
                                contractMaterial.Price = contractMaterial.Quantity * material.Price;
                                contractMaterial.Cost = contractMaterial.Quantity * material.Cost;
                                break;
                            case 18:
                                //Çift yönlü Sayac
                                contractMaterial.Quantity = 2;
                                contractMaterial.Price = contractMaterial.Quantity * material.Price;
                                contractMaterial.Cost = contractMaterial.Quantity * material.Cost;
                                break;
                            case 19:
                                //ALİMİNYUM TUTUCU
                                contractMaterial.Quantity = (int) ((entity.PanelPower / 450) * 4);
                                contractMaterial.Price = contractMaterial.Quantity * material.Price;
                                contractMaterial.Cost = contractMaterial.Quantity * material.Cost;
                                break;
                            case 20:
                                //GALVANİZLİ TOPRAKLAMA VE KABLO TAŞIMA SİSTEMİ
                                contractMaterial.Quantity = (int) ((entity.PanelPower / 450) / 4);
                                contractMaterial.Price = contractMaterial.Quantity * material.Price;
                                contractMaterial.Cost = contractMaterial.Quantity * material.Cost;
                                break;
                            case 21:
                                //Uzaktan İzleme Terminali-SMART LOGGER - DONGLE-4G - HUAWEI
                                //=ROUNDUP((SUM(F4:F12)/4);0)
                                contractMaterial.Quantity = 1;
                                contractMaterial.Price = contractMaterial.Quantity * material.Price;
                                contractMaterial.Cost = contractMaterial.Quantity * material.Cost;
                                break;
                            case 26:
                                //4x10 mm2 NYY Kablo
                                //=(SUM(F4:F10))*80
                                contractMaterial.Quantity = 80;
                                contractMaterial.Price = contractMaterial.Quantity * material.Price;
                                contractMaterial.Cost = contractMaterial.Quantity * material.Cost;
                                break;
                            case 28:
                                //1x6 mm2 NYAF Topraklama Kablosu
                                contractMaterial.Quantity = (int) (entity.PanelPower / 450);
                                contractMaterial.Price = contractMaterial.Quantity * material.Price;
                                contractMaterial.Cost = contractMaterial.Quantity * material.Cost;
                                break;
                            case 29:
                                //AC KABLOLAR-BAKIR KABLO
                                contractMaterial.Quantity = (int) ((entity.PanelPower / 450) / 10);
                                contractMaterial.Price = contractMaterial.Quantity * material.Price;
                                contractMaterial.Cost = contractMaterial.Quantity * material.Cost;
                                break;
                            case 31:
                                //Galvanizli Topraklama Kazığı
                                contractMaterial.Quantity = (int?) Math.Ceiling((entity.PanelPower / 450) / 100);
                                contractMaterial.Price = contractMaterial.Quantity * material.Price;
                                contractMaterial.Cost = contractMaterial.Quantity * material.Cost;
                                break;
                            case 32:
                                //Topraklama Dağıtım Klemensi
                                contractMaterial.Quantity = (int?) Math.Ceiling((entity.PanelPower / 450) / 400);
                                contractMaterial.Price = contractMaterial.Quantity * material.Price;
                                contractMaterial.Cost = contractMaterial.Quantity * material.Cost;
                                break;
                            case 33:
                                //Kroşe, Tekli Topraklama
                                contractMaterial.Quantity = (int?) Math.Ceiling((entity.PanelPower / 450) / 400);
                                contractMaterial.Price = contractMaterial.Quantity * material.Price;
                                contractMaterial.Cost = contractMaterial.Quantity * material.Cost;
                                break;
                            case 34:
                                //Eşpotansiyel Bara
                                contractMaterial.Quantity = (int?) Math.Ceiling((entity.PanelPower / 450) / 400);
                                contractMaterial.Price = contractMaterial.Quantity * material.Price;
                                contractMaterial.Cost = contractMaterial.Quantity * material.Cost;
                                break;
                        }

                        _repository.ContractMaterials.Add(contractMaterial);
                    }
                }
                else
                {
                    var contractMaterial = new ContractMaterial()
                    {
                        ContractId = entity.Id,
                        MaterialId = material.Id,
                        Quantity = 1
                    };
                    switch (material.Id)
                    {
                        case 24:
                            //Ana Dağıtım Panosu
                            contractMaterial.Cost = 1000;
                            contractMaterial.Price = 1200 + entity.PanelPower / 400;
                            break;
                        case 25:
                            //Pano Şalt Malzemeleri
                            contractMaterial.Cost = 300;
                            contractMaterial.Price = 1200 + entity.PanelPower / 180;
                            break;
                        case 40:
                            //Tüm ekipmanın kurulumu
                            contractMaterial.Cost = 175;
                            contractMaterial.Price = 1000 + (entity.PanelPower / 1000) * 8;
                            break;
                        case 52:
                            //Konaklama
                            contractMaterial.Cost = 190;
                            contractMaterial.Price = 100 + (entity.PanelPower / 1100);
                            break;
                        case 54:
                            //Nakliye
                            contractMaterial.Cost = 1900;
                            contractMaterial.Price = 100 + (((entity.PanelPower / 450) / 40) * 500) / 7;
                            break;
                        case 56:
                            //Nakliye Sigortası
                            contractMaterial.Cost = 190;
                            contractMaterial.Price = (100 + ((((entity.PanelPower / 450) / 40) * 500) / 7)) / 10;
                            break;
                        case 57:
                            //Ferdi Kaza Sigortası
                            contractMaterial.Cost = 190;
                            contractMaterial.Price = (100 + ((((entity.PanelPower / 450) / 40) * 500) / 7)) / 10;
                            break;
                        case 58:
                            //Personel Yemek Giderleri
                            contractMaterial.Cost = 450;
                            contractMaterial.Price = 100 + entity.PanelPower / 900;
                            break;
                        // case 72:
                        //     //MONTAJ VE İŞÇİLİK
                        //     //contractMaterial.Cost = 1900;
                        //     //contractMaterial.Price = (100 + ((((entity.PanelPower / 450) / 40) * 500) / 7)) / 10;
                        //     break;
                    }

                    _repository.ContractMaterials.Add(contractMaterial);
                }
            }

            await _repository.CommitAsync();

            var contractMaterials = _repository.ContractMaterials.GetAll();
            contractMaterials = contractMaterials.Where(s => s.ContractId == entity.Id).ToList();

            var contractPrice = contractMaterials.Select(d => d.Price).Sum();
            contractPrice = contractPrice + contractPrice * 0.08 + 1000; //MONTAJ VE İŞÇİLİK
            
            var contractCost = contractMaterials.Select(s => s.Cost).Sum();
            contractCost = contractCost + (contractPrice * 0.08 + 1000) * 0.8; //MONTAJ VE İŞÇİLİK

            entity.Cost = contractCost;
            entity.Price = contractPrice;

            entity.TotalPrice = contractPrice + contractPrice * 0.18;
            entity.TotalCost = contractCost + contractCost * 0.18;
            
            _repository.Contracts.Update(entity);
            await _repository.CommitAsync();

            return entity.Id;
        }
    }
}