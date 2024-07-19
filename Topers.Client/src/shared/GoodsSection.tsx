import React, { useEffect, useState } from 'react';
import axios from 'axios';
import GoodCard from '../widgets/GoodCard';
import { Box, Flex, Heading } from '@chakra-ui/react';
import { Good } from '../entities/Good';

export default function GoodsSection() {
    const [goods, setGoods] = useState<Good[]>([]);
    const baseUrl = 'http://localhost:5264';

    useEffect(() => {
        axios.get<Good[]>(`${baseUrl}/api/goods`)
        .then(response => {
            setGoods(response.data);
            console.log(response.data);
        })
        .catch(error => {
            console.error("There are some problems: ", error);
        });
    }, []);

    return (
        <Box bg='teal' borderRadius='20px' padding='20px'>
            <Heading
                pt='20px'
                pb='20px'
            >Our goods</Heading>
            <Flex 
                wrap='wrap'
                justify='center'
                gap='10%'>
                {goods.map(good => (
                    <React.Fragment key={good.id}>
                        <Heading>{good.name}</Heading>
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
                    </React.Fragment>
                ))}
            </Flex>
        </Box>
    );
}
