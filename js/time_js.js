// JavaScript Document

var aImg=[];
var time_arr=[];
var time=null;
window.onload=function()
{
	var oDiv=document.getElementById("top_time")
	var oImg=oDiv.getElementsByTagName("img")
	
	for(var i=0;i<oImg.length;i++){
		if(!isNaN(parseInt(oImg[i].alt))){
			aImg.push(oImg[i]);	
		}
	}
	
	var vvv=document.getElementsByClassName("nicEdit-main")

    vvv[0].style.height="60px";
    vvv[0].style.overflow="scroll"
	
	
}	
	var oDate=new Date();
	var iHour=oDate.getHours();
	var iMin=oDate.getMinutes();
	var iSec=oDate.getSeconds();
	if(iHour<10){
		iHour='0'+iHour
	}
	if(iMin<10){
		iMin='0'+iMin
	}
	if(iSec<10){
		iSec='0'+iSec
	}
	var str_time=""+iHour+iMin+iSec;
	var time_arr=str_time.split("");
	
	clearInterval(time);
	time=setInterval(atime,1);
	
	function atime(){
		var oDate=new Date();
	var iHour=oDate.getHours();
	var iMin=oDate.getMinutes();
	var iSec=oDate.getSeconds();
	if(iHour<10){
		iHour='0'+iHour
	}
	if(iMin<10){
		iMin='0'+iMin
	}
	if(iSec<10){
		iSec='0'+iSec
	}
	var str_time=""+iHour+iMin+iSec;
	var time_arr=str_time.split("");
	
		for(var i=0;i<aImg.length;i++){
			aImg[i].src="../time_pic/"+time_arr[i]+".png"
		}
	}
