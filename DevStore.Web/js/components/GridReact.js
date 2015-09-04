var React = require('react');
var FluxCartActions = require('../actions/FluxCartActions');


var GridRow = React.createClass({
    handleClick: function(item){
        FluxCartActions.removeItem(item);
    },
    render: function(){
        var itens = this.props.Cart.Itens.map(function(result,i){
            return <tr key={i}>
                        <td>{result.Developer.User}</td>
                        <td>{result.Developer.Price}</td>
                        <td>
                            <button onClick={this.handleClick(result)}></button> 
                        </td>
                    </tr>;
        }); 
    }
});

var Grid = React.createClass({
    getInitialState:function(){
        return {cart:{}};
    },
    render: function () {
        return <table className="table">
                    <thead>
                        <tr>
                            <th>Usuário</th>
                            <th>Preço</th>
                            <th>#</th>
                        </tr>
                    </thead>
                    <tbody>
                        <GridRow Cart={this.state.cart} />
                    </tbody>
            </table>;
    }
});
module.exports = Grid;