import { Router } from 'express';
import { redirectUrl, shortenUrl } from './controllers/urlController.js';

const router = Router();

router.get('/', () => {    
    console.log('teste') 
});

router.post('/shorten', shortenUrl);

router.get('/:shortCode', redirectUrl);

export default router;