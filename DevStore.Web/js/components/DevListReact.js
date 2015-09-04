var React = require('react');
var DevStore = require('../stores/DevStore');


var DevProfile = React.createClass({

    render:function(){
        return <div className="col-sm-6 col-md-4">
                    <div className="thumbnail">
                       <img src={this.props.Image} />
                        <div className="caption">
                          <h3>{this.props.Name}</h3>
                        </div>
                    </div>
              </div>;
    }

});

var DevListChild = React.createClass({
    
    render: function () {
        return <li>
               <DevProfile  Name={this.props.Dev.User} Image="Image" /> 
            </li>;
        
    }
});

var DevListReact = React.createClass({
    getInitialState:function(){
        return {data:DevStore.GetPage(1)};
    },
    render: function () {
        var devs = this.state.data.map(function(dev){
            return <DevListChild Dev={dev} />;
        });
        return <ul>
                {devs}
            </ul>;
    }
});

module.exports = DevListReact;