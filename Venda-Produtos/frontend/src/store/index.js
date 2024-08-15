import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    user: null,
    products: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user;
    },
    setProducts(state, products) {
      state.products = products;
    }
  },
  actions: {
    async fetchProducts({ commit }) {
      const response = await axios.get('/api/produto');
      commit('setProducts', response.data);
    },
    async login({ commit }, { email, password }) {
      const response = await axios.post('/api/usuario/authenticate', { email, password });
      commit('setUser', response.data);
    }
  },
  modules: {}
});
