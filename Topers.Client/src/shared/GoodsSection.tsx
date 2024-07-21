import React, { useEffect, useState } from 'react';
import { GoodCard } from '../widgets/GoodCard';
import { Box, Flex, Grid, Heading } from '@chakra-ui/react';
import { Good } from '../entities/Good';
import { GetAllGoods } from '../features/Goods';

export default function GoodsSection() {
    const [goods, setGoods] = useState<Good[]>([]);
    const baseUrl = 'http://localhost:5264';

    useEffect(() => {
        const fetchGoods = async() => {
            const goodsData = await GetAllGoods();
            setGoods(goodsData);
        }
        fetchGoods();
    }, []);

    return (
        <Box bg='#F7F7F7' borderRadius='20px' padding='20px'>
            <Heading
                pt='20px'
                pb='20px'
            >Our goods</Heading>
            <Box>
            {goods.map(good => (
                    <React.Fragment key={good.id}>
                        <Box>
                            <Grid 
                                templateColumns='repeat(2, 1fr)' 
                                gap='10'>
                                {good.scopes.map(scope => (
                                        <Box key={scope.id} flex="1 0 300px" maxW="300px">
                                            <GoodCard 
                                                goodId={scope.id}
                                                goodTitle={good.name}
                                                goodDescription={good.description}
                                                goodLitre={scope.litre}
                                                goodImage={`${baseUrl}/resources/${scope.imageName}`}
                                                goodPrice={scope.price}
                                            />
                                        </Box>
                                    ))}
                            </Grid>
                        </Box>
                    </React.Fragment>
                ))}
            </Box>
        </Box>
    );
}
