//layui.define(['layer', 'form'], function (exports) {
//	var layer = layui.layer
//		, form = layui.form;

//	layer.msg('Hello World');

//	console.log(1);

//	exports('index',{}); //注意，这里是模块输出的核心，模块名必须和use时的模块名一致
//});  




//定义一个模块，第一个参数可以加上 [] 中括号，表示模块加载依赖
layui.define(function (exports) {
	//do something
	console.log("demo加载完成"); //加载完成的处理

	//1、定义一个模块，该exports的个数必须只有一个
	//2、并且模块名称、文件名称必须一致
	//3、exports第二个参数可以是对象，也可以是方法
	exports('demo', {
		//自定义模块对象内部方法
		func: function (index) {
			console.log("demo.func(" + index+")");
		}
	});



	//第二个没用
	//exports('demo2', function () {
	//	console.log("demo2()");
	//});
});