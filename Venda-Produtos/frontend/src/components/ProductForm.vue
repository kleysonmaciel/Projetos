<template>
    <div>
        <h2>{{ isEdit ? 'Editar Produto' : 'Adicionar Produto' }}</h2>
        <form @submit.provent="handleSubmit">
            <div>
                <label for="nome">Nome:</label>
                <input type="text" v-model="produto.nome" required />
            </div>
            <div>
                <label for="preco">Preço:</label>
                <input type="number" v-model="produto.preco" required />
            </div>
            <div>
                <label for="quantidade_estoque">Quantidade em Estoque</label>
                <input type="number" v-model="produto.quantidade_estoque" required />
            </div>
            <div>
                <label for="imagem_url">Imagem do Produto:</label>
                <input type="file" @change="handleFileUpload" />
            </div>
            <button type="submit">{{ isEdit ? 'Salvar' : "Adicionar" }}</button>
        </form>
    </div>
</template>
<script>
import axios from 'axios';
export default{
    props:{
        produto_id:{
            type: Number,
            default: null
        }
    },
    data(){
        return{
            produto:{
                nome: '',
                preco:'',
                quantidade_estoque:'',
                imagem_url:''
            },
            isEdit: false
        };
    },
    methods:{
        async handleSubmit(){
            if(this.isEdit){
                await axios.put(`/api/produto/${this.produto_id}`, this.produto);
            }else{
                await axios.post('/api/produto', this.produto);
            }
            this.$router.push('/')
        },
        handleFileUpload(event){
            this.produto.imagem_url = event.target.files[0];
        }
    },
    async mounted(){
        if(this.produto_id){
            this.isEdit = true;
            const response = await axios.get(`/api/produto/${this.produto_id}`);
            this.produto = response.data;
        }
    }
};
</script>