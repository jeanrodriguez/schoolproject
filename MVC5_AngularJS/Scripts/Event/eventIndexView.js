
function LoadEventTable(eventUrl) {
    $('#eventIndexContainer').jtable({
        title: 'Table Of Event',
        //useBootstrap: true,
        actions: {
            listAction: eventUrl.getEvents,
            createAction: eventUrl.createEvent,
            updateAction: eventUrl.updateEvent,
            deleteAction: eventUrl.deleteEvent
        },
        fields: {
            Id: {
                key: true,
                list: false
            },
            Name: {
                title: 'Event',
                //width:''
            },
            EventStartDate: {
                title: 'Start Date',
                type: 'date'
            },
            EventEndDate: {
                title: 'End Date',
                type: 'date'
            },
            Description: {
                title: 'Description',
                type: 'textarea'
},
            Place: {
                title: 'Place'
            },
            Authors: {
                title: 'Author(s)'
            }
        }
    });
    $('#eventIndexContainer').jtable('load');
}