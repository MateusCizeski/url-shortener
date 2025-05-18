import { Router } from 'express';
import { redirectUrl, shortenUrl } from './controllers/urlController';

const routes = Router();

routes.get('/', () => {    
    console.log('teste') 
});

router.post('/shorten', shortenUrl);

router.get('/:shortCode', redirectUrl);

export default routes;