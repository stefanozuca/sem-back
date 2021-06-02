import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Table, TableContainer, TableHead, TableCell, TableBody, TableRow, Modal, Button, TextField, Select, MenuItem, InputLabel } from '@material-ui/core';
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
    const [empresas, setEmpresas] = useState([]);
    const [modalInsertar, setModalInsertar] = useState(false);
    const [modalEditar, setModalEditar] = useState(false);
    const [modalEliminar, setModalEliminar] = useState(false);

    const [obraSeleccionada, setObraSeleccionada] = useState({
        workItemId:'',
        title:'',
        description:'',
        company: ''
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
                console.log(response.data)
                setData(response.data);
            })
            .catch(response => {
                console.log(response);
            })
    }
    const obtenerEmpresas = async () => {
        await axios.get('api/v1/Company')
            .then(response => {
                setEmpresas(response.data);
            })
            .catch(response => {
                console.log(response);
            })
    }

    const insertarObra = async () => {
        await axios.post(baseUrl, {
            companyId: obraSeleccionada.company && obraSeleccionada.company.companyId,
            title: obraSeleccionada.title,
            description: obraSeleccionada.description
        })
        .then(response => {
            setData(data.concat({
                workItemId: obraSeleccionada.workItemId,
                title: obraSeleccionada.title,
                description: obraSeleccionada.description,
                company: obraSeleccionada.company
            }))
            abrirCerrarModalInsertar()
        })
        .catch(response => {
            console.log(response);
        })
    }

    const actualizarObra = async () => {
        console.log(obraSeleccionada);
        await axios.put(baseUrl + '/Update', {
            workItemId: obraSeleccionada.workItemId,
            title: obraSeleccionada.title,
            description: obraSeleccionada.description,
            companyId: obraSeleccionada.companyId
        })
        .then(response => {
            var dataNueva = data;
            dataNueva.map(obra =>{
                if (obraSeleccionada.workItemId === obra.workItemId){
                    obra.title = obraSeleccionada.title;
                    obra.description = obraSeleccionada.description;
                    obra.companyId = obraSeleccionada.companyId;
                }
            })
            setData(dataNueva);
            abrirCerrarModalEditar();
        })
        .catch(response => {
            console.log(response);
        })
    }

    const eliminarObra = async () => {
        await axios.delete(baseUrl + '/' + obraSeleccionada.workItemId)
        .then(response => {
            setData(data.filter(obra => obra.workItemId !== obraSeleccionada.workItemId));
            abrirCerrarModalEliminar();
        })
    }

    const abrirCerrarModalInsertar = () => {
        setModalInsertar(!modalInsertar);
    }

    const abrirCerrarModalEditar = () => {
        setModalEditar(!modalEditar);
    }
    
    const abrirCerrarModalEliminar = () => {
        setModalEliminar(!modalEliminar);
    }

    const seleccionarObra = (obra,caso) => {
        setObraSeleccionada(obra);
        (caso === 'Editar') ? abrirCerrarModalEditar() : abrirCerrarModalEliminar()
    }

    useEffect(async () => {
        await obtenerObras();
        await obtenerEmpresas();
    }, {})

    const bodyInsertar = (
        <div className={styles.modal}>
            <h4>Agregar nueva obra</h4>
            <TextField name="title" className={styles.inputMaterial} label="Titlo" onChange={handleChange}/>
            <br />
            <TextField name="description" className={styles.inputMaterial} label="Descripción" onChange={handleChange}/>
            <br />
            <InputLabel id="label-empresa-modal-crear">Empresa</InputLabel>
            <Select
            name="companyId"
            idLabel="label-empresa-modal-crear"
            onChange={handleChange}
            className={styles.inputMaterial}>
                {empresas.map(item => (
                    <MenuItem value={item.companyId}>{item.name}</MenuItem>
                    ))
                }
            </Select>
            <br /><br />
            <div align="right">
                <Button color="primary" onClick={()=>insertarObra()}>Insertar</Button>
                <Button onClick={()=>abrirCerrarModalInsertar()}>Cancelar</Button>
            </div>
        </div>
        )

    const bodyEditar = (
        <div className={styles.modal}>
            <h4>Editar obra</h4>
            <TextField name="title" className={styles.inputMaterial} label="Titulo" onChange={handleChange} value={obraSeleccionada && obraSeleccionada.title}/>
            <br />
            <TextField name="description" className={styles.inputMaterial} label="Descripción" onChange={handleChange} value={obraSeleccionada && obraSeleccionada.description}/>
            <br />
            <InputLabel id="label-empresa-modal-crear">Empresa</InputLabel>
            <Select
            value={obraSeleccionada && obraSeleccionada.company && obraSeleccionada.company.companyId}
            name="companyId"
            idLabel="label-empresa-modal-crear"
            onChange={handleChange}
            className={styles.inputMaterial}>
                {empresas.map(item => (
                    <MenuItem value={item.companyId}>{item.name}</MenuItem>
                    ))
                }
            </Select>
            <br /><br />
            <div align="right">
                <Button color="primary" onClick={()=>actualizarObra()}>Insertar</Button>
                <Button onClick={()=>abrirCerrarModalEditar()}>Cancelar</Button>
            </div>
        </div>
        )

    const bodyEliminar = (
        <div className={styles.modal}>
            <p>¿Estás seguro que deseas eliminar la esta obra?</p>
            <br /><br />
            <div align="right">
                <Button color="secondary" onClick={()=>eliminarObra()}>Si</Button>
                <Button onClick={()=>abrirCerrarModalEliminar()}>No</Button>
            </div>
        </div>
        )

    return (
        <div>
            <h1>Obras</h1>
            <br/>
            <Button onClick={()=>abrirCerrarModalInsertar()}>Insertar</Button>
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
                            <TableRow key={item.workItemId}>
                                <TableCell>{item.title}</TableCell>
                                <TableCell>{item.description}</TableCell>
                                <TableCell>{item.company && item.company.name}</TableCell>
                                <TableCell>
                                    <Edit onClick={()=>seleccionarObra(item, 'Editar')} className={styles.iconos}/>
                                    &nbsp;&nbsp;&nbsp;
                                    <Delete onClick={()=>seleccionarObra(item, 'Eliminar')} className={styles.iconos}/>
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

            <Modal
            open={modalEditar}
            onClose={abrirCerrarModalEditar}>
                {bodyEditar}
            </Modal>

            <Modal
            open={modalEliminar}
            onClose={abrirCerrarModalEliminar}>
                {bodyEliminar}
            </Modal>
        </div>
    );
}
