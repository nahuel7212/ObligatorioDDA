import React, { Component } from 'react';
import { Container, Row, Col } from 'react-grid-system';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import MaterialTable from 'material-table';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, FormGroup, Input, Label } from 'reactstrap';
import 'bootstrap/dist/css/bootstrap.css';
import axios from 'axios';
import { get, post } from 'jquery';

const columns = [
    {
        title: 'Id',
        field: 'id'
    },
    {
        title: 'Direccion de entrega',
        field: 'direccionEntrega'
    },
    {
        title: 'Tipo de pago',
        field: 'tipoPago'
    },
    {
        title: 'Precio total',
        field: 'precioTotal',
    },
    {
        title: 'Numero de tracking',
        field: 'numeroTracking'
    },
    {
        title: 'Documento/Rut cliente',
        field: 'documentoRutCliente'
    },
    {
        title: 'Fecha de agregado',
        field: 'fechaAgregado',
        //width: "5px"
    },
    {
        title: 'Descripcion contenido',
        field: 'descripcionContenido'
    },
    {
        title: 'Estado actual',
        field: 'estadoActual'
    },
];

export class EnviosComponent extends Component {
    //Get envios
    constructor(props) {
        super(props);
        this.state = { enviosData: [], loading: true };
    }

    componentDidMount() {
        this.getListadoEnvio();
    }

    async getListadoEnvio() {
        axios.get('Envio/GetListadoEnvios').then(response => this.setState({ enviosData: response.data, loading: false }))
    }

    static renderEnviosTable(enviosData) {
        return (
            <>
                <MaterialTable
                    columns={columns}
                    data={enviosData}
                    title="Envios registrados en el sistema" 
                    actions={[
                        {
                            icon: 'delete',
                            tooltip: 'Descargar PDF',
                            onClick: (event, rowData) => alert('Descargando PDF')
                        },
                        {
                            icon: 'delete',
                            tooltip: 'Cambiar estado',
                            onClick: (event, rowData) => window.confirm('Cambiar estado')
                        }
                    ]}
                    options={{
                        actionsColumnIndex: 0
                    }}
                    localization={{
                        header: {
                            actions: 'Acciones'
                        }
                    }}
                />
            </>
        );
    }

    //Estado modal
    state = {
        activo: false,
    }

    estadoModal = () => {
        this.setState({ activo: !this.state.activo });
    }

    //Datos agregar
    async AgregarEnvio() {
        var clienteRemitente = document.getElementById('clienteRemitente').value;
        var peso = document.getElementById('peso').value;
        var clienteDestinatario = document.getElementById('clienteDestinatario').value;
        var direccionEntrega = document.getElementById('direccionEntrega').value;
        var descripcionContenido = document.getElementById('descripcionContenido').value;

        var envio = {
            RemitenteId: clienteRemitente,
            PesoTotal: peso,
            ClienteDestinatarioId: clienteDestinatario,
            DireccionEntrega: direccionEntrega,
            DescripcionContenido: descripcionContenido
        };

        var x = axios.post('Envio/PostNuevoEnvio', envio)
            .then(response => console.log(response.data));

        console.log(x);
    }


    render() {
        let contentsTable = this.state.loading
            ? <p><em>Cargando...</em></p>
            : EnviosComponent.renderEnviosTable(this.state.enviosData);

        return (
            <>
                <div style={{ display: 'flex', justifyContent: 'center' }}>
                    <Button color="primary" onClick={this.estadoModal}> Agregar envio </Button>
                </div>

                <br/>

                {contentsTable}

                {/* Modal ingresar envio */} 
                <Modal isOpen={this.state.activo} size="lg">
                    <ModalHeader>
                        Ingresar envio
                                    </ModalHeader>

                    <ModalBody>
                        <Row>
                            <Col>
                                <Col>
                                    <FormGroup>
                                        <Label for="clienteRemitente"> Cliente remitente </Label>
                                        <Input type="text" id="clienteRemitente" />
                                    </FormGroup>
                                </Col>
                                <Col>
                                    <FormGroup>
                                        <Label for="peso"> Peso (en kilos) </Label>
                                        <Input type="text" id="peso" />
                                    </FormGroup>
                                </Col>
                            </Col>
                            <Col>
                                <Col>
                                    <FormGroup>
                                        <Label for="clienteDestinatario"> Cliente destinatario </Label>
                                        <Input type="text" id="clienteDestinatario" />
                                    </FormGroup>
                                </Col>
                                <Col>
                                    <FormGroup>
                                        <Label for="direccionEntrega"> Direccion entrega </Label>
                                        <Input type="text" id="direccionEntrega" />
                                    </FormGroup>
                                </Col>
                            </Col>
                        </Row>
                        <Row>
                            <Col>
                                <div style={{ paddingLeft: '15px', paddingRight: '15px' }}>
                                    <Label for="descripcionContenido"> Descripcion contenido </Label>
                                    <Input type="text" id="descripcionContenido"/>
                                </div>
                            </Col>
                        </Row>
                    </ModalBody>

                    <ModalFooter>
                        <Button color="secondary" onClick={this.estadoModal}> Cerrar </Button>
                        <br />
                        <Button color="success" style={{ width: '150px', height: '50px' }} onClick={this.AgregarEnvio}> Proceder a pagar </Button>
                    </ModalFooter>
                </Modal>
            </>
        );
    }
}