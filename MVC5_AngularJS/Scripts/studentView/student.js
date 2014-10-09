

function LoadStudentTable() {
    $('#studentContainer').jtable({
        title: 'Table of Students',
        actions: {
            listAction: window.studentUrls.getStudents,
            createAction: window.studentUrls.createStudent,
            updateAction: window.studentUrls.updateStudent,
            deleteAction: window.studentUrls.deleteStudent
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
            StreetAddress: {
                title: 'Street Address',
                type: 'textarea'
            },
            City: {
                title: 'City',
            },
            State: {
                title: 'State',
            },
            Email: {
                title: 'Email',
            },
            Sex: {
                title: 'Sex',
                //type: 'radiobutton'
                options: [{ Value: '1', DisplayText: 'Male' }, { Value: '2', DisplayText: 'Female' }]
            },
            Apartment: {
                title: 'Apartment',
            },
            ZipCode: {
                title: 'ZipCode',
            },
        }
    });
    $('#studentContainer').jtable("load");
}