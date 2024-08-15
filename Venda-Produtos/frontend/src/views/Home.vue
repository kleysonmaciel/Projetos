<template>
    <div class="home">
      <img :src="logo" alt="Logo" class="logo"/>
      <h1>Bem-vindo à Página Inicial</h1>
      <p>Esta é a página inicial da sua aplicação.</p>
    </div>
  </template>
  
  <script>
  import logo from '@/assets/images/logo.png';
  
  export default {
    name: "Home",
    data() {
      return {
        logo
      };
    }
  };
  </script>
  
  <style scoped>
  .logo {
    width: 100px;
    height: auto;
    margin-bottom: 20px;
  }
  </style>
  