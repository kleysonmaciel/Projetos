import React from 'react';
import {BrowserRouter as Router, Route, Routes} from 'react-router-dom';
import './styles/App.css';
import ClienteList from './components/ClienteList';
import ClienteForm from './components/ClienteForm';
import ClienteEdit from './components/ClienteEdit';

function App(){
    return(
        <Router>
        <div className="App">
          <h1>Cadastro de Clientes</h1>
          <Routes>
            <Route path="/" element={<ClienteList />} />
            <Route path="/adicionar" element={<ClienteForm />} />
            <Route path="/editar/:id" element={<ClienteEditWrapper />} />
          </Routes>
        </div>
      </Router>
    );
}
function ClienteEditWrapper(){
    const {id} = useParams();
    return <ClienteEdit id={id} />
}
export default App;