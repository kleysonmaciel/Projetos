<template>
    <div>
        <h2>Cobnfirmar Ação</h2>
        <p>{{ message }}</p>
        <button @click="confirmAction">Confirmar</button>
        <button @click="cancelAction">Cancelar</button>
    </div>
</template>

<script>
export default{
    props:{
        message: {
            type: String,
            required: true
        },
        confirmAction:{
            type: Function,
            required: true
        },
        cancelAction:{
            type: Function,
            required: true
        }
    }
};
</script>