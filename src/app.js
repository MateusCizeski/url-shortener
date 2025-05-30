import express from 'express';
import router from './routes.js';

const app = express();
app.use(express.json());

app.use('/api/urlShort', router);

export default app;