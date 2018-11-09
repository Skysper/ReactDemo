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
var Pager=React.createClass({
    componentDidMount:function()
    {
        console.log("pager:mount");
    },
    handlePageJump:function(i)
    {
        console.log(i);
        this.props.onHandlePageJump(i);
    },
    render:function()
    {
        var total=this.props.total;
        var current=this.props.current;
        var pSize=this.props.pageSize;
        var intResult=total%pSize;
        var maxPager=0;
        if(intResult==0) maxPager=total/pSize;
        else maxPager=total/pSize+1;

        var array=[];
        for(var i=1;i<=maxPager;i++)
        {
            if(i!=current)
            {
                array[i-1]=(<li> <a key={'pager'+i} href="javascript:;" onClick={this.handlePageJump.bind(this,i)}>{i}</a></li>);
        }else array[i-1]=(<li className="active"><span key={'pager'+i}>{i}</span></li>);
}
return (<ul key={'pager'} className="pagination">{array}</ul>);
}
});
//
var PagerList=React.createClass({
    render:function(){
        var childList = this.props.data.map(function(item){
            return (<tr>
                   <td>{item.Author}</td>
                   <td>{item.Content}</td>
                  </tr>);
        });
        return (<table className="table"><thead><tr><th>作者</th><th>内容</th></tr></thead>
        <tbody>{childList}</tbody></table>);
    }
});

var PageContent=React.createClass({
                                        jumpTo:function(i)
                                        {
                                            console.log("logindex:"+i);
                                            this.loadDataHandler(i);
                                        },
                                        loadDataHandler:function(i)
                                        {
                                            this.setState({'isFresh':true,'current':i});
                                            console.log("current"+this.state.current);
                                            //this.setState({current:i});
                                            $.post(urlConfig.list,{pageSize:this.props.pageSize,current:i},function(data){

                                                console.log(data);
                                                console.log("currentNew:"+this.state.current);
                                                this.setState({'data':data.list});
                                                this.setState({'total':data.total});
                                                this.setState({'isFresh':false});
                                                //this.setState({current:this.state.current});
                                            }.bind(this),'json');
                                        },
                                        getInitialState:function(){
                                            return {total:1,current:1,data:[],isFresh:false,isError:false};
                                        },
                                        componentDidMount:function()
                                        {
                                            console.log("mount");
                                            this.loadDataHandler(1);
                                        },
                
                                        render:function(){
                                           if(this.state.isFresh==true){
                                              return (<LoadPartial msg={"擦"}></LoadPartial>);
                                           }else if(this.state.isError==true)
                                           {
                                              return (<LoadPartial msg={"擦"}></LoadPartial>);
                                           }
                                           return(
                                            <div>
                                                 <PagerList data={this.state.data}></PagerList>
                                                 <Pager total={this.state.total} onHandlePageJump={this.jumpTo} current={this.state.current} pageSize={this.props.pageSize} ></Pager>
            </div>
      );
}
});

//ReactDOM.render(
//    (<PageContent pageSize={1}></PageContent>)
//    ,document.getElementById("content"));

$("#btnReload").bind("click",function(){
    ReactDOM.render(
    (<PageContent pageSize={1}></PageContent>)
    ,document.getElementById("content"));
});