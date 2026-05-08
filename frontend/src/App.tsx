import { useState, useEffect } from 'react';
import './App.css';
import { InputBase, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@mui/material';

interface Product {
    code: string;
    fullDescription :string;
    model: string;
    productGroup: string
    stockLevel: number;
}

function App() {
  const [productData, setProductData] = useState<Product[]>([]);
  const [code,setCode] = useState<string>("");
  const [partOfDescription,setPartOfDescription] = useState<string>("");
  const [error,setError] = useState<string>("");

  const getProductSearch = async (code :string, description :string) => {
    try {
        let response = await fetch(`/api/productList?code=${code}&description=${description}`);
        if (!response.ok) {
            console.log(response);
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        const rawProductList : Product[] = await response.json();
        setProductData(rawProductList);

    } catch (err) {
        setError(err instanceof Error ? err.message : 'Failed to fetch product data');
        console.log(error);
    }
  }

  useEffect(() => {
    getProductSearch(code, partOfDescription);
    console.log(productData);
  }, [code, partOfDescription]);

  return (
    <>
    <InputBase
        placeholder="Code"
        inputProps={{ 'aria-label': 'search' }}
        onChange={(e)=> setCode(e.target.value)}
    />
    <InputBase
        placeholder="Description"
        inputProps={{ 'aria-label': 'search' }}
        onChange={(e)=> setPartOfDescription(e.target.value)}
    />
    <TableContainer component={Paper}>
      <Table sx={{ minWidth: 650 }} >
        <TableHead>
          <TableRow>
            <TableCell>Code</TableCell>
            <TableCell>Description</TableCell>
            <TableCell>Model</TableCell>
            <TableCell>ProductGroup</TableCell>
            <TableCell>StockLevel</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {productData.map((product, index) => (
            <TableRow
              key={index}
            >
              <TableCell>{product.code}</TableCell>
              <TableCell>{product.fullDescription}</TableCell>
              <TableCell>{product.model}</TableCell>
              <TableCell>{product.productGroup}</TableCell>
              <TableCell>{product.stockLevel}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
    </>
  );
}

export default App;
