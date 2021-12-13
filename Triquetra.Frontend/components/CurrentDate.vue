<template>
  <div style="text-align: end">
    <v-spacer />
    <span>{{ timestamp }}</span>
  </div>
</template>

<script>
export default {
  name: 'CurrentDate',
  data () {
    return {
      timestamp: ''
    }
  },
  created () {
    this.getNow()
  },
  mounted () {
    setInterval(function () {
      this.getNow()
    }.bind(this), 1000)
  },
  methods: {
    getNow () {
      const today = new Date()
      const date = today.getDate() + '/' + (today.getMonth() + 1) + '/' + today.getFullYear()
      const time = today.getHours() + ':' + today.getMinutes() + ':' + today.getSeconds()
      this.timestamp = date + ' ' + time
    }
  }

}
</script>

<style scoped>

</style>
