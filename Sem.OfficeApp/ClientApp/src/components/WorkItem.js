import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Table, TableContainer, TableHead, TableCell, TableBody, TableRow, Modal, Button, TextField } from '@material-ui/core';
import { Edit, Delete } from '@material-ui/icons';
import { makeStyles } from '@material-ui/core/styles';

const baseUrl = 'api/v1/WorkItem';

const useStyles = makeStyles((theme) => ({
    modal: {
        position: 'absolute',
        width: 400,
        backgroundColor: theme.palette.background.paper,
        border: '2px solid #000',
        boxShadow: theme.shadows[5],
        padding: theme.spacing(2, 4, 3),
        top: '50%',
        left: '50%',
        transform: 'translate(-50%, -50%)'
    },
    iconos: {
        cursor:'pointer'
    },
    inputMaterial: {
        width:'100%'
    }
}));

export default function WorkItem() {

    const styles = useStyles();
    const [data, setData] = useState([]);
    const [modalInsertar, setModalInsertar] = useState(false);

    const [obraSeleccionada, setObraSeleccionada] = useState({
        titulo:'',
        decripcion:'',
        empresa: ''
    });

    const handleChange = e => {
        const {name, value} = e.target;
        setObraSeleccionada(prevState => ({
            ...prevState,
            [name]:value
        }))
    }

    const obtenerObras = async () => {
        await axios.get(baseUrl)
            .then(response => {
                setData(response.data);
            })
            .catch(response => {
                console.log(response);
            })
    }

    const insertarObra = async () => {
        await axios.post(baseUrl, obraSeleccionada)
        .then(response => {
            setData(data.concat(response.data))
            abrirCerrarModalInsertar()
        })
        .catch(response => {
            console.log(response);
        })
    }

    const abrirCerrarModalInsertar = () => {
        setModalInsertar(!modalInsertar);
    }

    useEffect(async () => {
        await obtenerObras();
    }, {})

    const bodyInsertar = (
        <div className={styles.modal}>
            <h4>Agregar nueva obra</h4>
            <TextField name="titulo" className={styles.inputMaterial} label="Titulo" onChange={handleChange}/>
            <br />
            <TextField name="descripcion" className={styles.inputMaterial} label="Descripción" onChange={handleChange}/>
            <br />
            <TextField name="empresa" className={styles.inputMaterial} label="Empresa" onChange={handleChange}/>
            <br /><br />
            <div align="right">
                <Button color="primary" onClick={insertarObra}>Insertar</Button>
                <Button onClick={abrirCerrarModalInsertar}>Cancelar</Button>
            </div>
        </div>
        )

    return (
        <div>
            <h1>Obras</h1>
            <br/>
            <Button onClick={abrirCerrarModalInsertar}>Insertar</Button>
            <br/>
            <TableContainer>
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell>Titulo</TableCell>
                            <TableCell>Descripción</TableCell>
                            <TableCell>Empresa</TableCell>
                            <TableCell>Acciones</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {data.map(item => (
                            <TableRow key={item.id}>
                                <TableCell>{item.titulo}</TableCell>
                                <TableCell>{item.descripcion}</TableCell>
                                <TableCell>{item.empresa}</TableCell>
                                <TableCell>
                                    <Edit />
                                    &nbsp;&nbsp;&nbsp;
                                    <Delete />
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>

            <Modal
            open={modalInsertar}
            onClose={abrirCerrarModalInsertar}>
                {bodyInsertar}
            </Modal>
        </div>
    );
}
