import Url from '../models/url.js';
import { nanoid } from 'nanoid';

import dotenv from 'dotenv';
dotenv.config();

const BASE_URL = process.env.BASE_URL || 'http://localhost:3000';

export async function shortenUrl(req, res) {
    const { originalUrl } = req.body;

    if(!originalUrl) return res.status(400).json({ error: 'URL é obrigatória' });

    const shortCode = nanoid(6);

    const newUrl = await Url.create({
        originalUrl,
        shortCode,
        expireAt: new Date(Date.now() + 7 * 24 * 60 * 60 * 1000)
    });

    res.status(201).json({
        shortUrl: `${BASE_URL}/${shortCode}`,
        originalUrl,
    });
}

export async function redirectUrl(req, res) {
    const { shortCode } = req.params;
    const url = await Url.findOne({ shortCode });

    console.log(url)

    if(!url) return res.status(404).json({ error: 'URL não encontrado.' });

    res.redirect(301, url.originalUrl);
}