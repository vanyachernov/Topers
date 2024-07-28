import axios from "axios";
import { Good } from "../entities/Good";

const baseUrl = 'http://localhost:5264';

export const GetAllGoods = async () => {
    try {
        const response = await axios.get<Good[]>(`${baseUrl}/api/goods`)
        return response.data;
    } catch (error) {
        console.error("Error in receiving goods: ", error);
        throw error;
    }
};

export const GetGoodById = async (id: string) => {
    try {
        const response = await axios.get<Good>(`${baseUrl}/api/goods/${id}`)
        return response.data;
    } catch (error) {
        console.error("Error in receiving good: ", error);
        throw error;
    }
};

export const UpdateGoodById = async (id: string, data: Good) => {
    try {
        const response = await axios.put<Good>(`${baseUrl}/api/goods/${id}`, data)
        return response.data;
    } catch (error) {
        console.error("Error in updating good: ", error);
        throw error;
    }
};

export const DeleteGoodsById = async (id: string) => {
    try {
        const response = await axios.delete<Good>(`${baseUrl}/api/goods/${id}`)
        return response.data;
    } catch (error) {
        console.error("Error in deleting good: ", error);
        throw error;
    }
};