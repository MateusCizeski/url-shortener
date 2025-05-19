import mongoose from "mongoose";

const schema = new mongoose.Schema({
    originalUrl: { type: String, required: true },
    shortCode: { type: String, required: true, unique: true },
    createdAt: { type: Date, default: Date.now },
    expireAt: { type: Date },
});

schema.index({ expireAt: 1 }, { expireAfterSeconds: 0 });

const Url = mongoose.model('Url', schema);

export default Url;