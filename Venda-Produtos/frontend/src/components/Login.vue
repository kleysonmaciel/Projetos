<template>
    <div class="login">
        <h2>Login</h2>
        <form @submit.prevent="login">
            <div>
                <label for="email">Email:</label>
                <input type="email" v-model="email" required/>
            </div>
            <div>
              <label for="password">Senha:</label> 
              <input type="password" v-model="password" required />
            </div>
            <button type="submit">Entrar</button>
        </form>
    </div>
</template>
<script>
import axios from 'axios';
export default{
    data(){
        return{
            email: '',
            password: ''
        };
    },
    methods:{
        async login(){
            try{
                const response = await axios.post('/api/usuario/authenticate',{
                    email: this.email,
                    password: this.password
                });
                //Redireciona para a página inicial
                this.$router.push('/');
            }catch(error){
                console.error('Erro de login:', error);
                alert('Email ou senha incorreto.');
            }
        }
    }
};
</script>