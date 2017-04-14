function Suraya(){
    var st = new UIStyle();
    var selectedValue;
    //*********************** Save function*********************
    this.Save = function(object){
        st.loading();
        $.ajax({
            url:object.url,
            type:'POST',
            data: object.form,
            //contentType: "application/json; charset=utf-8",
            contentType: false,       // The content type used when sending data to the server.
            cache: false,             // To unable request pages to be cached
            processData:false,
            async:false,
            success:function(data){
                st.hideloading();
                setTimeout(function () {
                    if (data =='success')
                        st.success();
                    else
                        st.error();
                }, 1000);
                
            return false;
            },
            error: function () {
                st.hideloading();
                setTimeout(function () {
                    st.error();
                }, 1000);
            	
            	return false;
            }
        });
         
    };
    //******************** Delete function***********************
    this.Delete = function(object){
        $.ajax({
            url:object.url,
            type:'POST',
            data:object,
            success:function(){                 
            },
            error: function () {
            	alert('error');
            }
        });
    }
     
    //******************* Gete data function*************************
    this.Getdata = function (object) {
    	st.loading();
        var result='';
        if (!object.values)
        {
                $.ajax({
                url:object.url,
                type:'POST',
                dataType:'json',
                //data:object,
                async:false,
                success:function(data){
                    result = data;
                },
                error: function () {
                	alert('error');
                }
            });
        }
        else if(object.values)
        {
                $.ajax({
                url:object.url,
                type:'POST',
                data:object.values,
                dataType:'json',
                async:false,
                success:function(data){
                    result = data;
                },
                error: function (data) {
                	alert('No data found');
                }
            });
        }
        st.hideloading();
        return result;
    }


    this.Getdata_1 = function (object) {
        
        var result = '';
        if (!object.values) {
            $.ajax({
                url: object.url,
                type: 'POST',
                dataType: 'json',
                //data:object,
                async: false,
                success: function (data) {
                    result = data;
                },
                error: function () {
                    alert('error');
                }
            });
        }
        else if (object.values) {
            $.ajax({
                url: object.url,
                type: 'POST',
                data: object.values,
                dataType: 'json',
                async: false,
                success: function (data) {
                    result = data;
                },
                error: function (data) {
                    alert('No data found');
                }
            });
        }
       
        return result;
    }
   //**************** Load drop down ***********************
    this.loaddrop = function(url,object,select){
        st.loading(); 
        select.empty();
        $.ajax({
            url:url,
            type:'POST',
            dataType:'json',
            data:object,
            async:false,
            success:function(data){
                select.append('<option value="">Please select</option>');
                $.each(data,function(i,item){                   
                   select.append('<option value="'+data[i].key+'">'+data[i].val+'</option>');
                });
            st.hideloading();     
            }
        });
    }

    //**************--Load drop down for view bag--***********************
    this.loaddropV = function (object) {
        st.loading(); 
        object.select.empty();
        $.ajax({
            url: object.url,
            type: 'POST',
            dataType: 'json',
            data: object.values,
            async: false,
            success: function (data) {               
                $.each(data, function (i, item) {
                    object.select.append('<option value="' + data[i].Value + '">' + data[i].Text + '</option>');
                });
                st.hideloading();     
            }
        });
    }

    // ******************Drop down for JQgrid Column-***************
    this.JQGridDropDown = function (object) {
        var data = this.Getdata(object);
        var res = {};
        for (i = 0; i < data.length; i++) {
            res[data[i].Value] = data[i].Text;
        }
        return res;
    }
     
    
    //********************Populate Finder Table*************************
    this.loadtableFinder = function (object) {        
        selectedValue = {};
        var table = $('<table class="table" id="tableData" style="border: 1px #DDD solid;"></table>')
        var THEAD = $('<thead></thead>');
        var TBODY = $('<tbody></tbody>');

        var tHead = '';
        var tBody = '';

        $.ajax({
            url:object.url,
            type:'POST',
            dataType:'json',
            data:object.values,
            async:false,
            success: function (data) {
                //var object = data[0].ProductionDate;
               // var res = st.ARUP(object);
                tHead += '<tr>';
                for (var j = 0; j < object.ColumnHead.length; j++)
                {
                    tHead += '<th data-field="prenom" data-filter-control="input" data-sortable="true">' + object.ColumnHead[j] + '</th>';
                }
                tHead += '</tr>';
                THEAD.append(tHead);
                for(var i=0;i<data.length;i++)
                {
                    tBody+='<tr>'
                    for (var j = 0; j < object.ColumnHead.length; j++) {
                        if (object.ColumnVal[j].type=='date')
                            tBody += '<td class="td">' + st.FormatDateString(data[i][object.ColumnVal[j].id]) + '</td>';////alert(data[i][object.ColumnVal[j]]); 
                        else
                            tBody += '<td class="td">' + data[i][object.ColumnVal[j].id] + '</td>';////alert(data[i][object.ColumnVal[j]]); 
                    }
                    tBody += '</tr>';
                }                
                TBODY.append(tBody);
                table.append(THEAD);
                table.append(TBODY);
                
               // $('td:nth-child(1)').hide();
                //*********************Modal*****************************

                var $textAndPic = $('<div style="overflow-y:scroll; width:80%"></div>');
                $textAndPic.append(table);
                //**********************************************
                for (var j = 0; j < object.ColumnVal.length; j++) {
                    if (object.ColumnVal[j].hidden == true)                        
                        $('.table tr td:nth-child(1),tr th:nth-child(1)').hide();
                }
                //****************************************************

                //$('#tableData').DataTable();

                //*****************************************************
                //$(this).find('td').eq(0).css({"background-color":"F50"});
                //*************************************************** Text

                BootstrapDialog.show({
                    title: 'Search',
                    message: $textAndPic,
                    buttons: [{
                        label: 'OK',
                        action: function (dialogRef) {
                            for (var j = 0; j < object.ColumnVal.length; j++) {
                                selectedValue[object.ColumnVal[j].id] = $(".table tr.selected").find("td").eq(j).html();
                            }
                            if (selectedValue!=null)
                                object.CallBackFunction(selectedValue);
                            dialogRef.close();
                        }
                    }, {
                        label: 'Cancel',
                        action: function (dialogRef) {
                            dialogRef.close();
                        }
                    }]
                });

                $(document).on("click", ".table tr", function (e) {
                    $(this).addClass('selected').siblings().removeClass('selected');
                });
            }
        }); 
    }
    //********************Populate Finder Table For Report Viewer*************************
    this.loadReportTableFinder = function (object) {
            $.ajax({
            url: object.url,
            type: 'POST',
            dataType: 'json',
            data: object.values,
            async: false,
            success: function (data) {                
                //*********************Modal*****************************
                var $textAndPic = $('<div style="overflow-y:scroll;width:100%"></div>');
                $textAndPic.append(data);                
                //*************************************************** Text
                $('#tableData tr').click(function (event) {
                    alert($(this).attr('id')); //trying to alert id of the clicked row          

                });
                BootstrapDialog.show({
                    title: 'Search Report Parameter',
                    message: $textAndPic,
                    buttons: [{
                        label: 'OK',
                        action: function (dialogRef) {                            
                            object.CallBackCustomFun($(".table tr.selected").find("td").eq(0).html());
                            dialogRef.close();
                        }
                    }, {
                        label: 'Cancel',
                        action: function (dialogRef) {
                            dialogRef.close();
                        }
                    }]
                });

                $(document).on("click", ".table tr", function (e) {
                    $(this).addClass('selected').siblings().removeClass('selected');
                });
            }
        });

    }

    //*********************** Post Report Parameter*********************

    this.PostrptParm = function (object) {
        st.loading();
        $.ajax({
            url: object.url,
            type: 'POST',
            data: object.form,
            //contentType: "application/json; charset=utf-8",
            contentType: false,       // The content type used when sending data to the server.
            cache: false,             // To unable request pages to be cached
            processData: false,
            async: false,
            success: function (data) {
                st.hideloading();
                setTimeout(function () {
                    if (data == 'success'){
                        window.open(rootPath + '/ReportViewer/ReportViewer.aspx?ReportName=' + object.rptUrl)
                    }
                        
                    else
                        st.error();
                }, 1000);

                return false;
            },
            error: function () {
                st.hideloading();
                setTimeout(function () {
                    st.error();
                }, 1000);

                return false;
            }
        });

    };

    //*******************Refresh all controll************************

     this.RefreshControll = function () {
         $('form').find('input:text, input:password, input:file, select, textarea').val('');
         $('form').find('input:radio, input:checkbox').prop('checked', false).prop('selected', false);
     }
    //*******************Append List with form Data**************************** 
     this.addListWithForm = function (formdata, list, objectname) {
         for (index = 0; index < list.length; ++index) {
             for (var key in list[index]) {
                 var value = list[index][key];
                 formdata.append(objectname + '[' + index + '].' + key, value);
             }
         }
         return formdata;
     }
    //****************-- Neumeric field validation--************************
     this.NumericValidaton=function(txtid,msgid) {
         txtid.keypress(function (e) {
             //if the letter is not digit then display error and don't type anything
             if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                 //display error message
                 msgid.html("Digits Only").show().fadeOut("slow");
                 return false;
             }
         });
     }
    //*********************-- Date picker function--*****************************
     this.DatePicker = function () {
         $('.date-picker').datepicker({
             autoclose: true,
             todayHighlight: true
         })
     }

     this.CustomDialog = function (message) {

         var $textAndPic = $('<div style="overflow-y:scroll;width:100%"></div>');
         $textAndPic.append(message); 
         BootstrapDialog.show({
             title: 'Validation Message',
             message: $textAndPic,
             buttons: [{
                 label: 'OK',
                 action: function (dialogRef) {                     
                     dialogRef.close();
                 }
             },
             ]
         });
     }

     this.TGModal = function (message) {
         //$.dialog({
         //    title: 'Text content!',
         //    content: message,
         //    buttons: {
         //        aRandomButton: function () {
         //            // this will be removed.
         //        }
         //    }
         //});

         $.alert({
             title: 'Alert!',
             content: 'Simple alert!',
         });
     }
}

