	$(document).ready(function()
    {
       

            myXHR('get',{'path':'/about/'},'#about').done(function(json)
            { 
                var x = '<h2>'+json.title+'</h2>';
                x+='<p>'+json.description+'</p><br>';
                x+='<p>'+json.quote+'</p>';
                x+='<p>'+json.quoteAuthor+'</p>';
                $('#about').append(x);
            }); 
        
        
           myXHR('get',{'path':'/degrees/undergraduate/'},'#content').done(function(json) 
            { 
                
                 $.each(json.undergraduate,function(i,item)
                        {    var x="";
                             var y="";
                            
                            x+="<h2>"+item.title+"</h2>";
                            x+="<p>"+item.description+"</p>";
                      $('#undergradContent'+i).append(x);
                         $('#ugTitle'+i).append(item.title);
                        $.each(item.concentrations,function(i,item){
                            y+= "<p>"+item+"</p><br>";
                            
                        });
                         
                         $('#ugConc'+i).append(y);
                         
                        });
                           
            });
  
        
            myXHR('get',{'path':'/degrees/graduate/'},'#content').done(function(json)
            { 
                 
                 $.each(json.graduate,function(i,item)
                        {
                                
                                    var x="";
                                if(item.concentrations==undefined)
                                {
                                     x+="<h1>"+item.degreeName+"</h1><br>";
                                     x+="<h2>"+item.availableCertificates+"</h2>";
                                     $('#gradDegree').append(x);  
                                }
                                
                                else
                                {
                                     x+="<h2>"+item.title+"</h2>";
                                     x+="<p>"+item.description+"</p>";
                                     $('#gradContent'+i).append(x);
                                     $('#gTitle'+i).append(item.title);
                                     $('#gConc'+i).append(item[Object.keys(item)[3]]+"<br>");    
                                }
                                                        
                        });
                 
            });
        
            myXHR('get',{'path':'/people/faculty/'},'#people').done(function(json){
           
            $.each(json.faculty,function(i,item){
               
              // x+='< data-id="'+$(this)[0].username+'">'+$(this)[0].name+'<h6>';
               var x = '<div class="mask" data-id="'+item.username+'" onmouseover="facMore(this)" data-featherlight="#facDetail'+i+'">';
               x+='<p>'+item.name+'</p></div>';
               var y='<img src="'+item.imagePath+'"/>';
               $('#Faculty'+i).append(x);
               $('#Faculty'+i).prepend(y);
            
            });
            
            });
        
        
            myXHR('get',{'path':'/employment/degreeStatistics/'},'#box').done(function(json)
            { 
                     
                     var data = json[Object.keys(json)[0]]; 
                     $.each(data.statistics,function(i,item)
                    {   
                        var x ="<h2><span>"+item.value+"</span></h3>";
                            x+="<p>"+item.description+"</p>";
                          $('#degstats'+i).append(x);
                    });
            });

            myXHR('get',{'path':'/employment/employers/'},'#EmpStat').done(function(json)
            { 
                     var employer = json[Object.keys(json)[0]];
                     var x="<h2>"+employer.title+"</h2>"; 
                      $.each(employer.employerNames,function(i,item)
                    {   
                         x+="<h4>"+item+"</h4>";  
                    });
                 $('#employers').html(x);  
            });
        
            myXHR('get',{'path':'/employment/careers/'},'#EmpStat').done(function(json)
            { 
                     var career = json[Object.keys(json)[0]];
                     var x="<h2>"+career.title+"</h2>"; 
                      $.each(career.careerNames,function(i,item)
                    {   
                         x+="<h4>"+item+"</h4>";  
                    });
                 $('#careers').html(x);  
            });
        
         
        myXHR('get',{'path':'/research/byInterestArea'},'#research').done(function(json)
            {
                  
                   // console.log(json);
                    $.each(json,function(i,item)
                    {
                      //  console.log(item);
                        $.each(item,function(i,item2){
                       //     console.log(item2);
                              var x="";
                            var y= "";
                            x='<h3>'+item2.areaName+'</h3>';
                            $('#rArea'+i).append(x);
                            $.each(item2.citations,function(i,item3){
                                y+='<h4>'+item3+'</h4>'; 
                            });
                            $('#ra'+i).append(y);
                        });
                    });
                
            });
        
            myXHR('get',{'path':'/employment/coopTable/'},'#coop').done(function(json)
            { 
                     var y = json[Object.keys(json)[0]];
                     var x="<h2>"+y.title+"</h2>"; 
                     $(x).insertBefore('#coopTable'); 
                      $.each(y.coopInformation,function(i,item)
                    {   
                        $('#coopTable > tbody:last-child').append('<tr><td>'+item.employer+'</td><td>'+item.degree+'</td><td>'+item.city+'</td><td>'+item.term+'</td></tr>');
                    });
                  
            });
        
            myXHR('get',{'path':'/employment/employmentTable/'},'#profEmpTable').done(function(json)
            { 
                     var y = json[Object.keys(json)[0]];
                     var x="<h2>"+y.title+"</h2>"; 
                      $(x).insertBefore('#profEmpTable'); 
                      $.each(y.professionalEmploymentInformation,function(i,item)
                    {   
                        $('#profEmpTable > tbody:last-child').append('<tr><td>'+item.employer+'</td><td>'+item.degree+'</td><td>'+item.city+'</td><td>'+item.title+'</td><td>'+item.startDate+'</td></tr>');
                    });
                 
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
                $('#res0').append(x);
                    
            });
    
            myXHR('get',{'path':'/resources/studentServices'},'#resources').done(function(json)
            {
                var x="";
                var y = json[Object.keys(json)[0]];
                x = '<h2>'+y.title+'</h2>';
                $('#res1').append(x);                
            });
            
            myXHR('get',{'path':'/resources/studentServices/academicAdvisors/'},'#resources').done(function(json)
            {
                var x="";
                var y = json[Object.keys(json)[0]];
                x = '<h2>'+y.title+'</h2>';
                x += '<h3>'+y.description+'</h3>';
                $('#res1').append(x);   
            });
    
            myXHR('get',{'path':'/resources/studentServices/academicAdvisors/faq'},'#resources').done(function(json)
            {
                var x="";
                var y = json[Object.keys(json)[0]];
                x = '<h2>'+y.title+'</h2>';
                x += '<h3>'+y.contentHref+'</h3>';
                $('#res1').append(x);     
            });
             
             myXHR('get',{'path':'/resources/studentServices/professonalAdvisors'},'#resources').done(function(json)
            {
                var x="";
                var y = json[Object.keys(json)[0]];
                x = '<h2>'+y.title+'</h2>';
                $.each(y.advisorInformation,function(i,item)
                {
                    x+='<h4>'+item.name+'</h4>';
                    x+='<h4>'+item.department+'</h4>';
                    x+='<h4>'+item.email+'</h4>';  
                });
                $('#res1').append(x);     
            });
    
            myXHR('get',{'path':'/resources/studentServices/facultyAdvisors'},'#resources').done(function(json)
            {
                var x="";
                var y = json[Object.keys(json)[0]];
                x = '<h2>'+y.title+'</h2>';
                x += '<h3>'+y.description+'</h3>';
                $('#res1').append(x);     
            });
            
            myXHR('get',{'path':'/resources/studentServices/istMinorAdvising'},'#resources').done(function(json)
            {
                var x="";
                var y = json[Object.keys(json)[0]];
                x = '<h2>'+y.title+'</h2>';
                $.each(y.minorAdvisorInformation,function(i,item)
                {
                    x+='<h4>'+item.title+'</h4>';
                    x+='<h4>'+item.advisor+'</h4>';
                    x+='<h4>'+item.email+'</h4>';
                });
                $('#res1').append(x);     
            });
            
             myXHR('get',{'path':'/resources/studentAmbassadors'},'#resources').done(function(json)
            {
                var x="";
                var y = json[Object.keys(json)[0]];
                x = '<h2>'+y.title+'</h2>';
                $.each(y.subSectionContent,function(i,item)
                {
                    x+='<h4>'+item.title+'</h4>';
                    x+='<h4>'+item.description+'</h4>';
                });
                x+='<h3>'+y.applicationFormLink+'</h3>';
                x+='<h3>'+y.note+'</h3>';
                $('#res3').append(x);     
            });
     
          myXHR('get',{'path':'/resources/tutorsAndLabInformation'},'#resources').done(function(json)
            {
                var x="";
                var y = json[Object.keys(json)[0]];
                x = '<h2>'+y.title+'</h2>';
                x+='<h4>'+y.description+'</h4>'; 
                x+='<h4>'+y.tutoringLabHoursLink+'</h4>';
                $('#res2').append(x);                
            });
    
           myXHR('get',{'path':'/resources/forms/'},'#resources').done(function(json)
            {
                     
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
                         $('#res4').append(x);       
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
                $('#res5').append(x);
            });
   
 
            myXHR('get',{'path':'/footer/social/'},'#footer').done(function(json)
            {
                var x="";
                var y = json[Object.keys(json)[0]];
                x+= '<h2>'+y.title+'</h2>';
                x+= '<h4>'+y.tweet+'</h4>';
                x+= '<h4>'+y.by+'</h4>';
                x+= '<a href="'+y.twitter+'">'+y.twitter+'</a><br>';
                x+= '<a href="'+y.facebook+'">'+y.facebook+'</a>';
                $('#footer').append(x);
            });
     
            myXHR('get',{'path':'/footer/quickLinks'},'#footer').done(function(json)
            {
                var x="";
                var y = json[Object.keys(json)[0]];
                $.each(y,function(i,item){

                x+= '<a href="'+item.href+'">'+item.title+'</a>';
                });
                $('#footer').append(x);
            });
    
            myXHR('get',{'path':'/footer/copyright'},'#footer').done(function(json)
            {
                var x="";
                var y = json[Object.keys(json)[0]];
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
});   
    
function facMore(which)
{
    var id=$(which).attr('data-id');
    var Faculty = "";
         myXHR('get',{'path':'/people/faculty/username='+id}).done(function(json){
        // console.log(json);
             
            $.each(json,function(i,item)
                    {
                            Faculty+= '<p>'+item+'<p>';                            
                    });
            // console.log($(which).parent().children("div.lightbox"));
            
         });
    
         myXHR('get',{'path':'/research/byFaculty/username='+id}).done(function(json)
            {
                   
                  //  console.log((faculty[Object.keys(faculty)[0]]).username);
                    if((json[Object.keys(json)[1]]!=id )){
                        $(which).parent().children("div.lightbox").html(Faculty);
                        return;
                        
                    }
                    var x="";
                   // console.log(json[Object.keys(json)[2]]);
                    $.each(json[Object.keys(json)[2]],function(i,item)
                    {
                            Faculty+= '<p>'+item+'<p>';
                    });
             $(which).parent().children("div.lightbox").html(Faculty);
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