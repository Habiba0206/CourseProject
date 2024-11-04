import axios from 'axios';

const axiosInstance = axios.create({
  baseURL: 'https://course-project-backend-dydmcrhdf8cvbkan.eastus2-01.azurewebsites.net',
  headers: {
    'Content-Type': 'application/json',
  },
  timeout: 5000,
});

export default axiosInstance;
