import Vue from 'vue'
import axios from 'axios'
axios.defaults.baseURL = process.env.VUE_APP_BASE_URL
// axios.defaults.baseURL = 'http://serv2.fmxsolucoes.com.br:32086/'

Vue.use({
  install (Vue) {
    Vue.prototype.$http = axios
  }
})
