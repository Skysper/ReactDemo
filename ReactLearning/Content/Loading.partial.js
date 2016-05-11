var LoadPartial = React.createClass({
    getInitialState:function()
    {
        return ({msg:'加载中,请稍后...'});
    },
    componentDidMount:function()
    {
        console.log(this.props.msg);
        if(this.props.msg)
        {
            this.setState({msg:this.props.msg});
        }
    },
    render: function () {
        return (
            <div>{this.state.msg}</div>);
    }
});