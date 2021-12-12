import { setClient } from '~/services/apiservice'

export default ({ app, store }) => {
  setClient(app.$axios)
}
