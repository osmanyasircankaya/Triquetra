<template>
  <v-container>
    <v-row>
      <v-col cols="6">
        <v-card>
          <v-card-title>GÜNEŞ ŞİRKETİNİN HAZIRLADIĞI TEKLİF</v-card-title>
          <v-card-text>
            <v-simple-table dark>
              <template #default>
                <thead>
                  <tr>
                    <th>
                      MARKA
                    </th>
                    <th>
                      ADET
                    </th>
                    <th>
                      TUTAR
                    </th>
                  </tr>
                </thead>
                <tbody>
                  <tr
                    v-for="item in cartItems"
                    :key="item.name"
                  >
                    <td class="text-left">
                      {{ item.name }}
                    </td>
                    <td class="text-left">
                      {{ item.tlPrice }} TL
                    </td>
                  </tr>
                </tbody>
              </template>
            </v-simple-table>
          </v-card-text>
        </v-card>
      </v-col>
      <v-col cols="6" />
    </v-row>
  </v-container>
</template>

<script>
import apiservice from '~/services/apiservice'

export default {
  name: 'Offer',
  data () {
    return {
      offer: {},
      exchangeRates: [],
      lastExchangeRate: {}
    }
  },
  mounted () {
    this.getExchangeRates()
  },
  methods: {
    getExchangeRates () {
      apiservice.get('api/ExchangeRate').then((data) => {
        this.exchangeRates = data.data
        this.lastExchangeRate = this.exchangeRates.lastItem
      }).catch(() => {
      })
    }
  }
}
</script>
