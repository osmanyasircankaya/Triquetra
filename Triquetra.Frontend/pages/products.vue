<template>
  <v-container>
    <v-row>
      <v-col />
      <v-col>
        <v-card dark>
          <v-card-title>Parça Ekle</v-card-title>
        </v-card>
      </v-col>
      <v-col />
    </v-row>
    <v-row>
      <v-col class="text-center">
        <v-simple-table dark>
          <template #default>
            <thead>
              <tr>
                <th>
                  Id
                </th>
                <th>
                  İsim
                </th>
                <th>
                  Boyut
                </th>
                <th>
                  Fiyat (TL)
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
                  {{ item.tlPrice }}
                </td>
                <td class="text-left">
                  {{ item.dollarPrice }}
                </td>
                <td class="text-left">
                  {{ item.productTypeId }}
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

export default {
  data () {
    return {
      products: []
    }
  },
  mounted () {
    this.getProducts()
  },
  methods: {
    getProducts () {
      apiservice.get('api/Product').then((data) => {
        this.products = data.data
      }).catch(() => {
      })
    }
  }
}
</script>
