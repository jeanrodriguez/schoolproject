

function cargarTableCourse() {
    $('#courseContainer').jtable({
        title: 'Table of Courses',
        actions: {
            listAction: window.couseUrls.getCouses,
            createAction: window.couseUrls.createCourse,
            updateAction: window.couseUrls.updateCourse,
            deleteAction: window.couseUrls.deleteCourse
        },
        fields: {
            Id: {
                key: true,
                list: false
            },
            Name: {
                title: 'Course',
                width: '40%'
            },
            StartDate: {
                title: 'Start Date',
                width: '20%',
                type:'date'
            },
            EndDate: {
                title: 'End Date',
                width: '30%',
                type: 'date',
                //create: false,
                //edit: false
            },
            Estado: {
              title:'Estado'  
            }
        }
    });
    $('#courseContainer').jtable("load");
}
  
 