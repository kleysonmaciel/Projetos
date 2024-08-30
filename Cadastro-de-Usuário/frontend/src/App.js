import React from 'react';
import ClienteList from './components/ClienteList';
import ClienteForm from './components/ClienteForm';

function App(){
    return(
        <div className="App">
            <h1>Cadastro de Clientes</h1>
            <ClienteForm/>
            <ClienteList/>
        </div>
    );
}

export default App;