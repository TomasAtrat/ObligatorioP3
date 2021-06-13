window.onplay =load();

function load()
{

   
  
   
}

function Verificar()
{

	window.location="pagina.html";
}

function Aparecer()
{
   document.getElementById("Registro").style.display="block";
   document.getElementById("ingreso").style.display="none";
   document.getElementById("DivisarReclamos").style.display="none";

}

function Desaparecer()
{
   document.getElementById("Registro").style.display="none";
   document.getElementById("ingreso").style.display="block";
   document.getElementById("DivisarReclamos").style.display="none";

}




/*function ArmarTabla(Reclamos)
{
   var tabla ="";
   var botonVerDetalle="'<input type='}"button"' value="'+texto+'" onclick="'+funcion+'">'";
   
}*/

function agregarBoton(htmlID, texto, funcion) { 
	var o=document.getElementById(htmlID); 
	o.html+='<input type="button" value="'+texto+'" onclick="'+funcion+'">'; 
} 

function Escribir(Reclamos)
{
	var tabla="";

	//voy escribiendo en una variable los productos.
	for (var r=0; r<Reclamos.length;r++)
	{

		var OPedido=Pedidos[r];
		
			for (i in OPedido)
			{
				if (i == "NumeroDePedido")
				{
					tabla+= "<tr>" + "<th>" + OPedido[i] + "</th>";
				}
			}
			
			for (i in OPedido)
			{
				if (i == "CodigoDePedido")
				{
					tabla+= "<th>" + OPedido[i] + "</th>";
				}
			}
			
			for (i in OPedido)
			{
				if (i == "NumeroDeCliente")
				{
					tabla+= "<th>" + OPedido[i] + "</th>";
				}
			}

			for (i in OPedido)
			{
				if (i == "Producto")
				{
					tabla+= "<th>" + OPedido[i] + "</th>";
				}
			}

			for (i in OPedido)
			{
				if (i == "Cantidad")
				{
					tabla+= "<th>" + OPedido[i] + "</th>";
				}
			}		

			for (i in OPedido)
			{
				if (i == "FechaDeIngreso")
				{
					tabla+= "<th>" + OPedido[i] + "</th>";
				}
			}	

			


	}
		tabla +="</tr>"
		document.getElementById("div3").innerHTML=tabla;
		
}