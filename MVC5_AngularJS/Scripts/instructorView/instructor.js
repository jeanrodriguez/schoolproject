
function LoadInstructorTable(instructoUrl) {
    $('#instructoContainer').jtable({
        title: 'Table Of Instructor',
        actions: {
            listAction: instructoUrl.getInstructors,
            createAction: instructoUrl.createInstructor,
            updateAction: instructoUrl.updateInstructor,
            deleteAction: instructoUrl.deleteInstructor
        },

        fields: {
            Id: {
                key: true,
                list: false
            },
            Name: {
                title: 'Name',
            },
            LastName: {
                title: 'LastName',
            },
            Telephone: {
                title: 'Telephone',
            },
            Cellphone: {
                title: 'Cellphone',
            },
        }
    });
    $('#instructoContainer').jtable('load');
}