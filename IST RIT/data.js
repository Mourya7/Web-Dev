	//now what?
	//api:  http://www.ist.rit.edu/api/
	$(document).ready(function()
        {
        var win = $(window);

	// Each time the user scrolls
	win.scroll(function() {
		// End of the document reached?
		if ($(document).height() - win.height() == win.scrollTop()) {
			$('#loading').show();

			$.ajax({
				url: 'get-post.php',
				dataType: 'html',
				success: function(html) {
					$('#posts').append(html);
					$('#loading').hide();
				}
			});
		}
	});
            myXHR('get',{'path':'/about/'},'#about').done(function(json)
            { 
                var x = '<h2>'+json.title+'</h2>';
                x+='<p>'+json.description+'</p><br/>';
                x+='<p>'+json.quote+'</p>';
                x+='<p>'+json.quoteAuthor+'</p>';
                $('#about').append(x);
            }); 
        });
            
           myXHR('get',{'path':'/degrees/undergraduate/'},'#content').done(function(json) 
            { 
                 var x="";
                 $.each(json.undergraduate,function(i,item)
                        {   
                            x+='<div class="majors" WWonclick="majorConcentrations(this)" data-id="'+$(this)[0].degreeName+'">';
                            x+="<h3>"+item.title+"</h3>";
                            x+="<p>"+item.description+"</p>";
                            x+="</div>";
                        });
                 x+="<br/><br/><br/>"
                 $('#Degrees').append(x);
                 
            });

        
            myXHR('get',{'path':'/degrees/graduate/'},'#content').done(function(json)
            { 
                 var x="";
                 $.each(json.graduate,function(i,item)
                        {
                            if(item.concentrations==undefined)
                                {
                                    x+="<h3>"+item.degreeName+"</h3>";
                                    x+="<h3>"+item.availableCertificates+"</h3><br/>";
                                }
                            else{
                                     
                                    x+="<h3>"+item.title+"</h3>";
                                    x+="<h4>"+item.description+"</h4>";
                                    x+="<h3>"+item.concentrations+"</h3><br/>";
                            }
                           
                        });
                 $('#Degrees').append(x);
                 
            });
        
          /*  myXHR('get',{'path':'/minors/UgMinors'},'#content').done(function(json)
            {
                    var x="";
                    $.each(json.UgMinors,function(i,item)
                        {
                            x+="<h3>"+item.name+"</h3><br/>";
                            x+="<h3>"+item.title+"</h3>";
                            x+="<h4>"+item.description+"</h4>";
                            x+="<h3>"+item.courses+"</h3><br/>";
                        });
                    $('#Degrees').append(x);
            });
        
         /*  myXHR('get',{'path':'/employment/'},'#employment').done(function(json)
            { 
                    var x=""; 
                    var item2;
                  //  console.log(json);
                    $.each(json,function(i,item)
                    {
                        
                      //  console.log(item.title);
                        x+="<h1>"+item.title+"</h1>";
                        var y = item[Object.keys(item)[1]];
                       
                        if(item.title=="Employers")
                            {
                                x+="<h4>"+item[Object.keys(item)[1]]+"</h4>";
                            }
                        if(item.title=="Careers")
                            {
                                x+="<h4>"+item[Object.keys(item)[1]]+"</h4>";
                            }
                        if(item.title=="Co-op Table")
                            {
                                $.each(y,function(k,item3){
                                    
                                    $('#coopTable > tbody:last-child').append('<tr><td>'+item3.employer+'</td><td>'+item3.degree+'</td><td>'+item3.city+'</td><td>'+item3.term+'</td></tr>');
                                });
                            }
                         if(item.title=="Professional Employment Table")
                            {
                                $.each(y,function(k,item3){
                                    $('#profEmpTable > tbody:last-child').append('<tr><td>'+item3.employer+'</td><td>'+item3.degree+'</td><td>'+item3.city+'</td><td>'+item3.title+'</td><td>'+item3.startDate+'</td></tr>');
                                });
                            }
                        $.each(y,function(j,item2){
                           // console.log(item2);
                           if(item2.title!=undefined && item2.description!=undefined){
                                x+="<h2>"+item2.title+"</h2>";
                                x+="<h4>"+item2.description+"</h4>";
                                
                            }
                            if(item2.value!=undefined && item2.description!=undefined){
                                x+="<h2>"+item2.value+"</h2>";
                                x+="<h4>"+item2.description+"</h4>";
                                
                            }
                        
                        });
                         
                    });
                $('#employment').append(x);
                    
            });
             
            myXHR('get',{'path':'/research/byInterestArea'},'#research').done(function(json)
            {
                    var x="";
                   // console.log(json);
                    $.each(json,function(i,item)
                    {
                      //  console.log(item);
                        $.each(item,function(i,item2){
                       //     console.log(item2);
                            x+='<h2>'+item2.areaName+'</h2>';
                            $.each(item2.citations,function(i,item3){
                               x+='<h4>'+item3+'</h4>'; 
                            });
                        });
                    });
                 $('#research').append(x);
            });
        
             myXHR('get',{'path':'/research/byFaculty'},'#research').done(function(json)
            {
                    var x="";
                   // console.log(json);
                    $.each(json,function(i,item)
                    {
                       // console.log(item);
                        $.each(item,function(i,item2){
                           // console.log(item2);
                            x+='<h2>'+item2.facultyName+'</h2>';
                            x+='<h3>'+item2.username+'</h3>';
                            $.each(item2.citations,function(i,item3){
                               x+='<h4>'+item3+'</h4>'; 
                            });
                        });
                    });
                 $('#research').append(x);
            });
            
              myXHR('get',{'path':'/resources'},'#resources').done(function(json)
            {
                var x = '<h2>'+json.title+'</h2>';
                x+='<h4>'+json.subTitle+'</h4>';
                var y;
                $('#resources').append(x);
            });
      
        
            myXHR('get',{'path':'/resources/studyAbroad'},'#resources').done(function(json)
            {
                var x="";
                var y = json[Object.keys(json)[0]];
              //  console.log(y);
                x = '<h2>'+y.title+'</h2>';
                x+='<h4>'+y.description+'</h4>';
               // x+='<h4>'+y.places+'</h4>';
                $.each(y.places,function(i,item)
                {
                    x+='<h4>'+item.nameOfPlace+'</h4>';
                    x+='<h4>'+item.description+'</h4>';
                });
                $('#resources').append(x);
                    
            });
    
            myXHR('get',{'path':'/resources/studentServices'},'#resources').done(function(json)
            {
                var x="";
                var y = json[Object.keys(json)[0]];
                x = '<h1>'+y.title+'</h1>';
                $('#resources').append(x);                
            });
            
            myXHR('get',{'path':'/resources/studentServices/academicAdvisors/'},'#resources').done(function(json)
            {
                var x="";
                var y = json[Object.keys(json)[0]];
                x = '<h1>'+y.title+'</h1>';
                x += '<h3>'+y.description+'</h3>';
                $('#resources').append(x);   
            });
    
            myXHR('get',{'path':'/resources/studentServices/academicAdvisors/faq'},'#resources').done(function(json)
            {
                var x="";
                var y = json[Object.keys(json)[0]];
                x = '<h1>'+y.title+'</h1>';
                x += '<h3>'+y.contentHref+'</h3>';
                $('#resources').append(x);     
            });
             
             myXHR('get',{'path':'/resources/studentServices/professonalAdvisors'},'#resources').done(function(json)
            {
                var x="";
                var y = json[Object.keys(json)[0]];
                x = '<h1>'+y.title+'</h1>';
                $.each(y.advisorInformation,function(i,item)
                {
                    x+='<h4>'+item.name+'</h4>';
                    x+='<h4>'+item.department+'</h4>';
                    x+='<h4>'+item.email+'</h4>';  
                });
                $('#resources').append(x);     
            });
    
            myXHR('get',{'path':'/resources/studentServices/facultyAdvisors'},'#resources').done(function(json)
            {
                var x="";
                var y = json[Object.keys(json)[0]];
                x = '<h1>'+y.title+'</h1>';
                x += '<h3>'+y.description+'</h3>';
                $('#resources').append(x);     
            });
            
            myXHR('get',{'path':'/resources/studentServices/istMinorAdvising'},'#resources').done(function(json)
            {
                var x="";
                var y = json[Object.keys(json)[0]];
                x = '<h1>'+y.title+'</h1>';
                $.each(y.minorAdvisorInformation,function(i,item)
                {
                    x+='<h4>'+item.title+'</h4>';
                    x+='<h4>'+item.advisor+'</h4>';
                    x+='<h4>'+item.email+'</h4>';
                });
                $('#resources').append(x);     
            });
            
             myXHR('get',{'path':'/resources/studentAmbassadors'},'#resources').done(function(json)
            {
                var x="";
                var y = json[Object.keys(json)[0]];
                x = '<h1>'+y.title+'</h1>';
                $.each(y.subSectionContent,function(i,item)
                {
                    x+='<h4>'+item.title+'</h4>';
                    x+='<h4>'+item.description+'</h4>';
                });
                x+='<h3>'+y.applicationFormLink+'</h3>';
                x+='<h3>'+y.note+'</h3>';
                $('#resources').append(x);     
            });
     
            myXHR('get',{'path':'/resources/tutorsAndLabInformation'},'#resources').done(function(json)
            {
                var x="";
                var y = json[Object.keys(json)[0]];
                x = '<h2>'+y.title+'</h2>';
                x+='<h4>'+y.description+'</h4>'; 
                x+='<h4>'+y.tutoringLabHoursLink+'</h4>';
                $('#resources').append(x);                
            });
    
            myXHR('get',{'path':'/resources/forms/'},'#resources').done(function(json)
            {
                        console.log(json);
                        var x="";
                        var y = json[Object.keys(json)[0]];
                        $.each(y[Object.keys(y)[0]],function(i,item)
                        {
                            x+='<h4>'+item.formName+'</h4>';
                            x+='<h4>'+item.href+'</h4>';
                        });
                        
                        $.each(y[Object.keys(y)[1]],function(i,item)
                        {
                             x+='<h4>'+item.formName+'</h4>';
                             x+='<h4>'+item.href+'</h4>';
                        });
                         $('#resources').append(x);       
            });
            
            myXHR('get',{'path':'/resources/coopEnrollment/'},'#resources').done(function(json)
            {
                var x="";
                var y = json[Object.keys(json)[0]];
                
                x = '<h2>'+y.title+'</h2>';
                $.each(y[Object.keys(y)[1]],function(i,item){
                    x+='<h4>'+item.title+'</h4>';
                    x+='<h4>'+item.description+'</h4>';
                });
                x+='<h4>'+y.RITJobZoneGuidelink+'</h4>';
                $('#resources').append(x);
            });
            
             myXHR('get',{'path':'/news/'},'#news').done(function(json)
            {
                var x="";
                
                $.each(json[Object.keys(json)[0]],function(i,item){
                    x+='<h4>'+item.date+'</h4>';
                    x+='<h4>'+item.title+'</h4>';
                    x+='<h4>'+item.description+'</h4>';
                });
                $.each(json[Object.keys(json)[1]],function(i,item){
                    x+='<h4>'+item.date+'</h4>';
                    x+='<h4>'+item.title+'</h4>';
                    x+='<h4>'+item.description+'</h4>';
                });
                $.each(json[Object.keys(json)[2]],function(i,item){
                    x+='<h4>'+item.date+'</h4>';
                    x+='<h4>'+item.title+'</h4>';
                    x+='<h4>'+item.description+'</h4>';
                });
                $('#news').append(x); 
             
             });
    
            myXHR('get',{'path':'/footer/social/'},'#footer').done(function(json)
            {
                var x="";
                var y = json[Object.keys(json)[0]];
                console.log(y);
                x+= '<h2>'+y.title+'</h2>';
                x+= '<h4>'+y.tweet+'</h4>';
                x+= '<h4>'+y.by+'</h4>';
                x+= '<h4>'+y.twitter+'</h4>';
                x+= '<h4>'+y.facebook+'</h4>';
                $('#footer').append(x);
            });
     
            myXHR('get',{'path':'/footer/quickLinks'},'#footer').done(function(json)
            {
                var x="";
                var y = json[Object.keys(json)[0]];
                console.log(y);
                $.each(y,function(i,item){
                x+= '<h2>'+item.title+'</h2>';
                x+= '<h4>'+item.href+'</h4>';
                });
                $('#footer').append(x);
            });
    
            myXHR('get',{'path':'/footer/copyright'},'#footer').done(function(json)
            {
                var x="";
                var y = json[Object.keys(json)[0]];
                console.log(y);
                x+= '<h2>'+y.title+'</h2>';
                x+= '<h4>'+y.html+'</h4>';
                
                $('#footer').append(x);
            });
            
            myXHR('get',{'path':'/footer/'},'#footer').done(function(json)
            {
                var x="";
                var y = json[Object.keys(json)[3]];
                
                x+= '<h2>'+y+'</h2>';
    
                $('#footer').append(x);
            });
             
    */
    //////////////////////////////////////Ajax util/////////////////////////////////
    ////in: (t,d)
    //// t = "get" or "post"
    //// d = {"path":"/undergrad."}
    ////return:ajax object ready to consume the callback
    ///////////////////////////////////////////////////// 
function facMore(w){
        console.log(w);
        var id=$(w).attr('data-id');
         myXHR('get',{'path':'/people/faculty/username'+id}).done(function(json){
         console.log(json);   
         });
    //x+='<div h6 onclick="facMore(this)" data-id="'+$(this)[0].username+'">'+$(this)[0].name+'<h6>';
    }  
function majorConcentrations(which)
{
    var id=$(which).attr('data-id');
    myXHR('get',{'path':'/degrees/undergraduate/degreeName='+id}).done(function(json){
        
         
                var x = "<h4>"+json[Object.keys(json)[3]]+"</h4>";
        
                $('#Degrees').append(x);
         });
}
function myXHR(t,d,id)
    {
    return  $.ajax(
            {
                type:t,
                dataType:'json',
                cache:false,
                async:true,
                url:'proxy.php',
                data:d,
                beforeSend:function()
                {
            
                }
            }).always(function()
            {
                
            }).fail(function()
            {
                //handle failure

            }).done(function()
            {
            
            });
    }