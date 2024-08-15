<template>
    <div class="login">
        <h2>Login</h2>
        <form @submit.prevent="login">
            <div>
                <label for="email">Email:</label>
                <input type="email" v-model="email" required>
            </div>
            <div>
                <label for="password">Senha:</label>
                <input type="password" v-model="password" required>
            </div>
            <button type="submit">Entrar</button>
        </form>
    </div>
</template>

<script>
import {mapActions} from 'vuex';
export default{
    name: "Login",
    data(){
        return{
            email: '',
            password: ''
        };
    },
    methods:{
        ...mapActions(['login']),
        async login(){
            try{
                await this.login({email: this.email, password: this.password});
                this.$router.push('/');
            }catch(error){
                alert('Login falhou: ' + error.response.data.message);
            }
        }
    }
};
</script>
<style scoped>
.login{
    max-width: 400px;
    margin: 0 auto;
    padding: 20px;
    border: 1px solid #ccc;
    border-radius: 8px;
}
.login h2{
    text-align: center;
}
.login form div{
    margin-bottom: 15px;
}

.login label{
    display: block;
    margin-bottom: 5px;
}
.login input{
    width: 100%;
    padding: 8px;
    box-sizing: border-box;
}

.login button{
    width: 100%;
    padding: 10px;
    background-color: #42b983;
    border: none;
    color: white;
    font-size: 16px;
    cursor: pointer;
}

.login button:hover{

    background-color: #379f76;
}
</style>