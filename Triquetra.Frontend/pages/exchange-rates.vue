<template>
  <v-container>
    <v-row>
      <v-col cols="6" class="text-center">
        <v-simple-table dark>
          <template #default>
            <thead>
              <tr>
                <th>
                  Tarih
                </th>
                <th>
                  Tutar
                </th>
              </tr>
            </thead>
            <tbody>
              <tr
                v-for="item in exchangeRates"
                :key="item.date"
              >
                <td class="text-left">
                  {{ $moment(item.date).locale("tr").format("DD/MM/YYYY") }}
                </td>
                <td class="text-left">
                  {{ item.amount }}
                </td>
              </tr>
            </tbody>
          </template>
        </v-simple-table>
      </v-col>
      <v-col cols="3" />
      <v-col cols="3">
        <CurrentDate />
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
import apiservice from '~/services/apiservice'

export default {
  data () {
    return {
      exchangeRates: []
    }
  },
  mounted () {
    this.getExchangeRates()
  },
  methods: {
    getExchangeRates () {
      apiservice.get('api/ExchangeRate').then((data) => {
        this.exchangeRates = data.data
      }).catch(() => {
      })
    }
  }
}
</script>
