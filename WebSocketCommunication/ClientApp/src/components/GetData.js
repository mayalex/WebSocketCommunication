import React, { Component } from 'react';

export class GetData extends Component {
    constructor(props) {
        super(props);
        this.state = { tableRows: [] };
    }

    componentWillMount() {
        var getWebSocketMessages = onMessageReceived => {
            var url = `ws://${window.location.host}/api/SampleData`;

            var webSocket = new WebSocket(url);

            webSocket.onmessage = onMessageReceived;
        };

        getWebSocketMessages(message => {
            if (message.data) {
                let tableRows = this.state.tableRows;
                tableRows.push(JSON.parse(message.data));
                this.setState({ tableRows });
            }
        });
    }
    renderTableRows = data => {
        return data
            ? data.map(row => (
                  <tr key={row[0]}>
                      <td>{row[0]}</td>
                      <td>{row[1]}</td>
                      <td>{row[2]}</td>
                  </tr>
              ))
            : null;
    };

    render() {
        return (
            <React.Fragment>
                <table className="table">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Data col 1</th>
                            <th>Data row 2</th>
                        </tr>
                    </thead>
                    <tbody>{this.renderTableRows(this.state.tableRows)}</tbody>
                </table>
            </React.Fragment>
        );
    }
}
