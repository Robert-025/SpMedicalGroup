import axios from 'axios';

//Define uma constante para fazer as requisições da API
const api = axios.create({
    baseURL: 'http://localhost:5000/api',
});

export default api;