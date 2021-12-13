<template>
  <v-container>
    <v-row>
      <v-col>
        <v-card dark>
          <v-card-title>
            PARÇA EKLE
          </v-card-title>
          <v-card-text>
            <v-row>
              <v-col>
                <v-text-field
                  v-model="product.Name"
                  outlined
                  hide-details
                  dark
                  label="İsim"
                  required
                  onpaste="return false;"
                />
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <v-text-field
                  v-model="product.Size"
                  outlined
                  hide-details
                  dark
                  type="number"
                  label="Boyut"
                  required
                />
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <v-text-field
                  v-model="product.DollarPrice"
                  outlined
                  hide-details
                  dark
                  type="number"
                  label="Fiyat ($)"
                  required
                />
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <v-select
                  v-model="product.ProductTypeId"
                  outlined
                  hide-details
                  :items="productTypes"
                  :item-text="item => item.name"
                  :item-value="item => item.id"
                  label="Tip"
                />
              </v-col>
            </v-row>
            <v-row>
              <v-col />
              <v-col />
              <v-col align="end">
                <v-btn dark color="indigo darken-4" @click="saveProduct">
                  KAYDET
                </v-btn>
              </v-col>
            </v-row>
          </v-card-text>
        </v-card>
      </v-col>
      <v-col cols="3" />
      <v-col cols="3">
        <CurrentDate />
      </v-col>
    </v-row>
    <v-row>
      <v-col class="text-center">
        <v-simple-table dark>
          <template #default>
            <thead>
              <tr>
                <th>
                  #
                </th>
                <th>
                  İsim
                </th>
                <th>
                  Boyut
                </th>
                <th>
                  Fiyat (Dolar)
                </th>
                <th>
                  Tip
                </th>
              </tr>
            </thead>
            <tbody>
              <tr
                v-for="item in products"
                :key="item.Name"
              >
                <td class="text-left">
                  {{ item.id }}
                </td>
                <td class="text-left">
                  {{ item.name }}
                </td>
                <td class="text-left">
                  {{ item.size }}
                </td>
                <td class="text-left">
                  {{ item.dollarPrice }}
                </td>
                <td class="text-left">
                  <span v-if="item.productTypeId === 1">İnvertör</span>
                  <span v-else>Panel</span>
                </td>
              </tr>
            </tbody>
          </template>
        </v-simple-table>
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
import apiservice from '~/services/apiservice'
import CurrentDate from '~/components/CurrentDate'

export default {
  components: { CurrentDate },
  data () {
    return {
      products: [],
      product: {},
      productTypes: []
    }
  },
  mounted () {
    this.getProducts()
    this.getProductTypes()
  },
  methods: {
    getProducts () {
      apiservice.get('api/Product').then((data) => {
        this.products = data.data
      }).catch(() => {
      })
    },
    getProductTypes () {
      apiservice.get('api/ProductType').then((data) => {
        this.productTypes = data.data
      }).catch(() => {
      })
    },
    saveProduct () {
      apiservice.post('api/Product', this.product).then((data) => {
        this.getProducts()
        this.product = {}
      }).catch(() => {
      })
    }
  }
}
</script>
