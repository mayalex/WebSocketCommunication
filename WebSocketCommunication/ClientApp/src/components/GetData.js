import React, { Component } from 'react';

export class GetData extends Component {
  constructor(props) {
    super(props);
    this.state = { table: [] };
  }

  componentWillMount() {
    var getWebSocketMessages = onMessageReceived => {
      var url = `ws://${window.location.host}/api/SampleData`;

      var webSocket = new WebSocket(url);

      webSocket.onmessage = onMessageReceived;
    };

    getWebSocketMessages(message => {
      if (message.data) {
        this.setState({ table: JSON.parse(message.data) });
      }
    });
  }
  renderTableRows = table => {
    return table
      ? table.map(row => (
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
          <tbody>{this.renderTableRows(this.state.table)}</tbody>
        </table>
      </React.Fragment>
    );
  }
}
