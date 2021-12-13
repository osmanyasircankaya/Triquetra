<template>
  <v-container>
    <v-row>
      <v-col col="6">
        <v-card>
          <v-card-title>
            DOLAR KURU GİRİŞİ
          </v-card-title>
          <v-card-text>
            <v-row>
              <v-col>
                <v-menu
                  v-model="menu1"
                  :close-on-content-click="false"
                  :nudge-right="40"
                  transition="scale-transition"
                  offset-y
                  min-width="auto"
                >
                  <template #activator="{ on, attrs }">
                    <v-text-field
                      v-model="exchangeRate.Date"
                      dark
                      label="Tarih"
                      prepend-icon="mdi-calendar"
                      readonly
                      v-bind="attrs"
                      v-on="on"
                    />
                  </template>
                  <v-date-picker
                    v-model="exchangeRate.Date"
                    locale="tr"
                    dark
                    @input="menu1 = false"
                  />
                </v-menu>
              </v-col>
              <v-col>
                <v-text-field
                  v-model="exchangeRate.Amount"
                  dark
                  label="Miktar"
                  type="number"
                  required
                />
              </v-col>
            </v-row>
            <v-row>
              <v-col />
              <v-col />
              <v-col align="end">
                <v-btn dark color="indigo darken-4" @click="saveExchangeRate">
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
  </v-container>
</template>
<script>
import apiservice from '~/services/apiservice'

export default {
  data () {
    return {
      exchangeRate: { Date: (new Date(Date.now() - (new Date()).getTimezoneOffset() * 60000)).toISOString().substr(0, 10), Amount: 0 },
      menu1: false
    }
  },

  methods: {
    saveExchangeRate () {
      apiservice.post('api/ExchangeRate', this.exchangeRate).then(() => {
        this.exchangeRate = { Date: (new Date(Date.now() - (new Date()).getTimezoneOffset() * 60000)).toISOString().substr(0, 10), Amount: 0 }
      }).catch(() => {
      })
    }
  }
}
</script>
