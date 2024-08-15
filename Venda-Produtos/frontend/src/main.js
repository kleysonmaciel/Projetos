// src/main.js
import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import store from './store';
import './assets/styles/global.css'; // Importação dos estilos globais

createApp(App)
  .use(router)
  .use(store)
  .mount('#app');
