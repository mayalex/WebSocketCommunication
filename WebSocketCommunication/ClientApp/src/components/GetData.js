import React, { Component } from 'react';

export class GetData extends Component {
    constructor(props) {
        super(props);
        this.state = { data: [] };

    }

    componentWillMount() {
        var getWebSocketMessages = onMessageReceived => {
            var url = `ws://${window.location.host}/api/SampleData`

            var webSocket = new WebSocket(url);

            webSocket.onmessage = onMessageReceived;
        };

        getWebSocketMessages(message => {
            let data = this.state.data;
            data.push(message.data)
            this.setState({ data });
        });
    }
    renderTable = (data) => {
        return (
            <table className='table'>
                <tbody>
                    {data.map(item =>
                        <tr key={item}>
                            <td>{item}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {

        return (
            <React.Fragment>
                {this.renderTable(this.state.data)}
            </React.Fragment>
        );
    }
}
