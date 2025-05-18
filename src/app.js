import express from 'express';
import routes from './routes.js';

const app = express();

app.use('/api/urlShort', routes);

export default app;