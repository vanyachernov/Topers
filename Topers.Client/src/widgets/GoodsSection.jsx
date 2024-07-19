import React, { useEffect, useState } from 'react'
import axios from 'axios';
import GoodCard from './GoodCard'
import { Box } from '@chakra-ui/react';

export default function GoodsSection() {
    const [goods, setGoods] = useState([]);
    const baseUrl = 'http://localhost:5264';
    
    useEffect(() => {
        axios.get("http://localhost:5264/api/goods")
        .then(response => {
            setGoods(response.data);
        })
        .catch(error => {
            console.error("There are some problems: ", error);
        })
    , []})

  return (
    <Box>
        {goods.map(good => (
            <GoodCard 
                goodTitle={good.name}
                goodDescription={goods.description} />
        ))}
    </Box>
  )
}
