import app from "./app.js";
import connectDB from "./db/database.js";
import dotenv from 'dotenv';
dotenv.config();

const port = process.env.PORT || 3000;

connectDB().then(() => {
    app.listen(port, () => {
        console.log(`Server running at http://localhost:${port}`);
    });
});