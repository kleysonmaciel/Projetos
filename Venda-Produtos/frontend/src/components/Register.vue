<template>
    <div class="register">
        <h2>Registrar</h2>
        <form @submit.prevent="required">
            <div>
                <label for="nome">Nome:</label>
                <input type="text" v-model="nome" required />
            </div>
            <div>
                <label for="sobrenome">Sobrenome:</label>
                <input type="text" v-model="sobrenome" required>
            </div>
            <div>
                <label for="email">Email:</label>
                <input type="email" v-model="email" required />
            </div>
            <div>
                <label for="cpf">CPF</label>
                <input type="text" v-model="cpf" required />
            </div>
            <div>
                <label for="password">Senha:</label>
                <input type="password" v-model="password" required />
            </div>
            <button type="submit">Registrar</button>
        </form>
    </div>
</template>

<script>
import axios from 'axios';
export default{
    name: 'Register',
    data(){
        return{
            nome:'',
            sobrenome: '',
            email:'',
            cpf:'',
            password:''
        };
    },
    methods:{
        async register(){
            try{
                await axios.post('/api/usuario',{
                    nome: this.nome,
                    sobrenome: this.sobrenome,
                    email: this.email,
                    cpf: this.cpf,
                    password: this.password
                });
                alert('Registrado com sucesso');
                this.$router.push('/login'); //Redireciona para a página de login após o registro
            }catch(error){
                alert('Regitro falhou: '+ error.response.data.message);
            }
        }
    }
};
</script>
<style scoped>
.register{
    max-width: 400px;
    margin: 0 auto;
    padding: 20px;
    border: 1px solid #ccc;
    border-radius: 8px;
}
.register h2{
    text-align: center;
}
.register form div{
    margin-bottom: 15px;
}
.register label{
    display: block;
    margin-bottom: 5px;
}
.register input{
    width: 100%;
    padding: 10px;
    background-color: #42b983;
    border: none;
    color: white;
    font-size: 16px;
    cursor: pointer;
}
.register button:hover{
    background-color: #379f76;
}
</style>