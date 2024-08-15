<script setup lang="ts">
import router from './router';
</script>

<template>
    <div id="app">
        <router-view />
    </div>
</template>

<script>

export default{
    name: 'App'
};
</script>

<style>
body{
    font-family: Avenir, Helvetica, Arial, sans-serif;
    margin: 0;
    padding: 0;
}
</style>