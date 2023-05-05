import React, { Component } from 'react';
import Autocomplete from 'react-autocomplete';

export default class App extends Component {
    state = {
        selectedMemberId: '', dashboardData: {}, loading: true
    };

    componentDidMount() {
        fetch('dashboard')
            .then(r => r.json())
            .then(d => {
                this.setState({ dashboardData: d, loading: false })                
            });
    }

    render() {
        return (
            <>
                {
                    this.state.loading
                        ? <h1>Loading...</h1>
                        : <>
                            <h1>{this.state.dashboardData.thinkGroups[1].description}</h1>
                            <div className="autocomplete-wrapper">
                                <h3>Select a member to add to a group:</h3>
                                <Autocomplete
                                    value={this.state.selectedMemberId}
                                    items={this.state.dashboardData.members}
                                    getItemValue={item => item.memberId.toString()}
                                    getOptionSelected={item => item.fullName }
                                    shouldItemRender={item => item.fullName}
                                    renderMenu={item => (
                                        <div className="dropdown">
                                            {item}
                                        </div>
                                    )}
                                    renderItem={(item, isHighlighted) =>
                                        <div key={item.memberId} className={`item ${isHighlighted ? 'selected-item' : ''}`}>
                                            {item.fullName}
                                        </div>
                                    }
                                    onChange={(_event, val) => this.setState({ selectedMemberId: val })}
                                    onSelect={val => { this.setState({ selectedMemberId: val }); }}
                                />
                            </div>                            
                            <button onClick={() => this.doSomething(this.state.selectedMemberId)}>GO</button>
                        </>
                }
            </>
        );
    }

    doSomething(value) {
        alert(value);
    }

    renderDashboard(dashboard) {

        console.log(dashboard);
    }

    static renderMovieTitle(state, val) {
        return (
            state.title.toLowerCase().indexOf(val.toLowerCase()) !== -1
        );
    }

    static MoviesData() {
        return [
            { "title": "The Shawshank Redemption", "rank": "1", "id": "tt0111161" },
            { "title": "The Godfather", "rank": "2", "id": "tt0068646" },
            { "title": "The Godfather: Part II", "rank": "3", "id": "tt0071562" },
            { "title": "Pulp Fiction", "rank": "4", "id": "tt0110912" },
            { "title": "The Good, the Bad and the Ugly", "rank": "5", "id": "tt0060196" },
            { "title": "The Dark Knight", "rank": "6", "id": "tt0468569" },
            { "title": "12 Angry Men", "rank": "7", "id": "tt0050083" },
            { "title": "Schindler's List", "rank": "8", "id": "tt0108052" },
            { "title": "The Lord of the Rings: The Return of the King", "rank": "9", "id": "tt0167260" },
            { "title": "Fight Club", "rank": "10", "id": "tt0137523" },
            { "title": "Star Wars: Episode V - The Empire Strikes Back", "rank": "11", "id": "tt0080684" },
            { "title": "The Lord of the Rings: The Fellowship of the Ring", "rank": "12", "id": "tt0120737" },
            { "title": "One Flew Over the Cuckoo's Nest", "rank": "13", "id": "tt0073486" },
            { "title": "Inception", "rank": "14", "id": "tt1375666" },
            { "title": "Goodfellas", "rank": "15", "id": "tt0099685" },
            { "title": "Star Wars", "rank": "16", "id": "tt0076759" },
            { "title": "Seven Samurai", "rank": "17", "id": "tt0047478" },
            { "title": "Forrest Gump", "rank": "18", "id": "tt0109830" },
            { "title": "The Matrix", "rank": "19", "id": "tt0133093" },
            { "title": "The Lord of the Rings: The Two Towers", "rank": "20", "id": "tt0167261" },
            { "title": "City of God", "rank": "21", "id": "tt0317248" },
            { "title": "Se7en", "rank": "22", "id": "tt0114369" },
            { "title": "The Silence of the Lambs", "rank": "23", "id": "tt0102926" },
            { "title": "Once Upon a Time in the West", "rank": "24", "id": "tt0064116" },
            { "title": "Casablanca", "rank": "25", "id": "tt0034583" },
            { "title": "The Usual Suspects", "rank": "26", "id": "tt0114814" },
            { "title": "Raiders of the Lost Ark", "rank": "27", "id": "tt0082971" },
            { "title": "Rear Window", "rank": "28", "id": "tt0047396" },
            { "title": "It's a Wonderful Life", "rank": "29", "id": "tt0038650" },
            { "title": "Psycho", "rank": "30", "id": "tt0054215" },
            { "title": "Léon: The Professional", "rank": "31", "id": "tt0110413" },
            { "title": "Sunset Blvd.", "rank": "32", "id": "tt0043014" },
            { "title": "American History X", "rank": "33", "id": "tt0120586" },
            { "title": "Apocalypse Now", "rank": "34", "id": "tt0078788" },
            { "title": "Terminator 2: Judgment Day", "rank": "35", "id": "tt0103064" },
            { "title": "Saving Private Ryan", "rank": "36", "id": "tt0120815" },
            { "title": "Memento", "rank": "37", "id": "tt0209144" },
            { "title": "City Lights", "rank": "38", "id": "tt0021749" },
            { "title": "Dr. Strangelove or: How I Learned to Stop Worrying and Love the Bomb", "rank": "39", "id": "tt0057012" },
            { "title": "Alien", "rank": "40", "id": "tt0078748" },
            { "title": "Modern Times", "rank": "41", "id": "tt0027977" },
            { "title": "Spirited Away", "rank": "42", "id": "tt0245429" },
            { "title": "North by Northwest", "rank": "43", "id": "tt0053125" },
            { "title": "Back to the Future", "rank": "44", "id": "tt0088763" },
            { "title": "Life Is Beautiful", "rank": "45", "id": "tt0118799" },
            { "title": "The Shining", "rank": "46", "id": "tt0081505" },
            { "title": "The Pianist", "rank": "47", "id": "tt0253474" },
            { "title": "Citizen Kane", "rank": "48", "id": "tt0033467" },
            { "title": "The Departed", "rank": "49", "id": "tt0407887" },
            { "title": "M", "rank": "50", "id": "tt0022100" },
            { "title": "Paths of Glory", "rank": "51", "id": "tt0050825" },
            { "title": "Vertigo", "rank": "52", "id": "tt0052357" },
            { "title": "Django Unchained", "rank": "53", "id": "tt1853728" },
            { "title": "Double Indemnity", "rank": "54", "id": "tt0036775" },
            { "title": "The Dark Knight Rises", "rank": "55", "id": "tt1345836" },
            { "title": "Aliens", "rank": "56", "id": "tt0090605" },
            { "title": "Taxi Driver", "rank": "57", "id": "tt0075314" },
            { "title": "American Beauty", "rank": "58", "id": "tt0169547" },
            { "title": "The Green Mile", "rank": "59", "id": "tt0120689" },
            { "title": "Gladiator", "rank": "60", "id": "tt0172495" },
            { "title": "The Intouchables", "rank": "61", "id": "tt1675434" },
            { "title": "WALL·E", "rank": "62", "id": "tt0910970" },
            { "title": "The Lives of Others", "rank": "63", "id": "tt0405094" },
            { "title": "Toy Story 3", "rank": "64", "id": "tt0435761" },
            { "title": "The Great Dictator", "rank": "65", "id": "tt0032553" },
            { "title": "The Prestige", "rank": "66", "id": "tt0482571" },
            { "title": "A Clockwork Orange", "rank": "67", "id": "tt0066921" },
            { "title": "Lawrence of Arabia", "rank": "68", "id": "tt0056172" },
            { "title": "Amélie", "rank": "69", "id": "tt0211915" },
            { "title": "To Kill a Mockingbird", "rank": "70", "id": "tt0056592" },
            { "title": "Reservoir Dogs", "rank": "71", "id": "tt0105236" },
            { "title": "Das Boot", "rank": "72", "id": "tt0082096" },
            { "title": "The Lion King", "rank": "73", "id": "tt0110357" }
        ]
    }
}

//export default class App extends Component {
//    static displayName = App.name;

//    state = { val: '' };

//    constructor(props) {
//        super(props);
//        this.state = { forecasts: [], loading: true, val: '' };
//    }

//    componentDidMount() {
//        this.populateWeatherData();
//    }

//    static renderForecastsTable(forecasts) {

//        function handleClick() {
//            alert('hi');

//            fetch('dashboard')
//                .then(function (response) {
//                    var blah = response.json();
//                    return blah;
//                }).then(function (data) {
//                    console.log(data);
//                });
//            //.then(response => response.json())
//            //.then(json => console.log(json));

//            //const response = await fetch('viewmodel');
//            //const data = await response.json();
//            //alert(data.ThinkGroups.count);
//        }

//        return (
//            <table className='table table-striped' aria-labelledby="tabelLabel" onClick={handleClick} >
//                <thead>
//                    <tr>
//                        <th>Date</th>
//                        <th>Temp. (C)</th>
//                        <th>Temp. (F)</th>
//                        <th>Summary</th>
//                    </tr>
//                </thead>
//                <tbody>
//                    {forecasts.map(forecast =>
//                        <tr key={forecast.date}>
//                            <td>{forecast.date}</td>
//                            <td>{forecast.temperatureC}</td>
//                            <td>{forecast.temperatureF}</td>
//                            <td>{forecast.summary}</td>
//                        </tr>
//                    )}
//                </tbody>
//            </table >
//        );
//    }

//    static renderDashboard(dashboard) {

//        console.log(dashboard);

//        return (
//            <>
//                <select name="thinkGroup-to-add-to-member" id="thinkGroup-to-add-to-member">
//                    {dashboard.thinkGroups.map(item =>
//                        <option value={item.thinkGroupId}>{item.name}</option>
//                    )}
//                </select>
//                <div className="autocomplete-wrapper">
//                    <h3>React Autocomplete Demo</h3>
//                    <Autocomplete
//                        value={this.state.val}
//                        items={App.MoviesData()}
//                        getItemValue={item => item.title}
//                        shouldItemRender={App.renderMovieTitle}
//                        renderMenu={item => (
//                            <div className="dropdown">
//                                {item}
//                            </div>
//                        )}
//                        renderItem={(item, isHighlighted) =>
//                            <div className={`item ${isHighlighted ? 'selected-item' : ''}`}>
//                                {item.title}
//                            </div>
//                        }
//                        onChange={(event, val) => this.setState({ val })}
//                        onSelect={val => this.setState({ val })}
//                    />
//                </div>
//            </>
//        );
//    }

//    render() {
//        let contents = this.state.loading
//            ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
//            : App.renderForecastsTable(this.state.forecasts);
//        let dashboardView = this.state.loading
//            ? <p><em>Loading dashboard...</em></p>
//            : App.renderDashboard(this.state.dashboard);

//        return (
//            <div>
//                <h1 id="tabelLabel" >Weather forecast</h1>
//                <p>This component demonstrates fetching data from the server.</p>
//                {contents}
//                {dashboardView}
//            </div>
//        );
//    }

//    async populateWeatherData() {
//        const response = await fetch('weatherforecast');
//        const data = await response.json();
//        const dashResponse = await fetch('dashboard');
//        const dashData = await dashResponse.json();
//        dashData.selectedMemberId = -1;

//        console.log(dashData);

//        this.setState({ forecasts: data, dashboard: dashData, loading: false });
//    }

//    static renderMovieTitle(state, val) {
//        return (
//            state.title.toLowerCase().indexOf(val.toLowerCase()) !== -1
//        );
//    }

//    static MoviesData() {
//        return [
//            { "title": "The Shawshank Redemption", "rank": "1", "id": "tt0111161" },
//            { "title": "The Godfather", "rank": "2", "id": "tt0068646" },
//            { "title": "The Godfather: Part II", "rank": "3", "id": "tt0071562" },
//            { "title": "Pulp Fiction", "rank": "4", "id": "tt0110912" },
//            { "title": "The Good, the Bad and the Ugly", "rank": "5", "id": "tt0060196" },
//            { "title": "The Dark Knight", "rank": "6", "id": "tt0468569" },
//            { "title": "12 Angry Men", "rank": "7", "id": "tt0050083" },
//            { "title": "Schindler's List", "rank": "8", "id": "tt0108052" },
//            { "title": "The Lord of the Rings: The Return of the King", "rank": "9", "id": "tt0167260" },
//            { "title": "Fight Club", "rank": "10", "id": "tt0137523" },
//            { "title": "Star Wars: Episode V - The Empire Strikes Back", "rank": "11", "id": "tt0080684" },
//            { "title": "The Lord of the Rings: The Fellowship of the Ring", "rank": "12", "id": "tt0120737" },
//            { "title": "One Flew Over the Cuckoo's Nest", "rank": "13", "id": "tt0073486" },
//            { "title": "Inception", "rank": "14", "id": "tt1375666" },
//            { "title": "Goodfellas", "rank": "15", "id": "tt0099685" },
//            { "title": "Star Wars", "rank": "16", "id": "tt0076759" },
//            { "title": "Seven Samurai", "rank": "17", "id": "tt0047478" },
//            { "title": "Forrest Gump", "rank": "18", "id": "tt0109830" },
//            { "title": "The Matrix", "rank": "19", "id": "tt0133093" },
//            { "title": "The Lord of the Rings: The Two Towers", "rank": "20", "id": "tt0167261" },
//            { "title": "City of God", "rank": "21", "id": "tt0317248" },
//            { "title": "Se7en", "rank": "22", "id": "tt0114369" },
//            { "title": "The Silence of the Lambs", "rank": "23", "id": "tt0102926" },
//            { "title": "Once Upon a Time in the West", "rank": "24", "id": "tt0064116" },
//            { "title": "Casablanca", "rank": "25", "id": "tt0034583" },
//            { "title": "The Usual Suspects", "rank": "26", "id": "tt0114814" },
//            { "title": "Raiders of the Lost Ark", "rank": "27", "id": "tt0082971" },
//            { "title": "Rear Window", "rank": "28", "id": "tt0047396" },
//            { "title": "It's a Wonderful Life", "rank": "29", "id": "tt0038650" },
//            { "title": "Psycho", "rank": "30", "id": "tt0054215" },
//            { "title": "Léon: The Professional", "rank": "31", "id": "tt0110413" },
//            { "title": "Sunset Blvd.", "rank": "32", "id": "tt0043014" },
//            { "title": "American History X", "rank": "33", "id": "tt0120586" },
//            { "title": "Apocalypse Now", "rank": "34", "id": "tt0078788" },
//            { "title": "Terminator 2: Judgment Day", "rank": "35", "id": "tt0103064" },
//            { "title": "Saving Private Ryan", "rank": "36", "id": "tt0120815" },
//            { "title": "Memento", "rank": "37", "id": "tt0209144" },
//            { "title": "City Lights", "rank": "38", "id": "tt0021749" },
//            { "title": "Dr. Strangelove or: How I Learned to Stop Worrying and Love the Bomb", "rank": "39", "id": "tt0057012" },
//            { "title": "Alien", "rank": "40", "id": "tt0078748" },
//            { "title": "Modern Times", "rank": "41", "id": "tt0027977" },
//            { "title": "Spirited Away", "rank": "42", "id": "tt0245429" },
//            { "title": "North by Northwest", "rank": "43", "id": "tt0053125" },
//            { "title": "Back to the Future", "rank": "44", "id": "tt0088763" },
//            { "title": "Life Is Beautiful", "rank": "45", "id": "tt0118799" },
//            { "title": "The Shining", "rank": "46", "id": "tt0081505" },
//            { "title": "The Pianist", "rank": "47", "id": "tt0253474" },
//            { "title": "Citizen Kane", "rank": "48", "id": "tt0033467" },
//            { "title": "The Departed", "rank": "49", "id": "tt0407887" },
//            { "title": "M", "rank": "50", "id": "tt0022100" },
//            { "title": "Paths of Glory", "rank": "51", "id": "tt0050825" },
//            { "title": "Vertigo", "rank": "52", "id": "tt0052357" },
//            { "title": "Django Unchained", "rank": "53", "id": "tt1853728" },
//            { "title": "Double Indemnity", "rank": "54", "id": "tt0036775" },
//            { "title": "The Dark Knight Rises", "rank": "55", "id": "tt1345836" },
//            { "title": "Aliens", "rank": "56", "id": "tt0090605" },
//            { "title": "Taxi Driver", "rank": "57", "id": "tt0075314" },
//            { "title": "American Beauty", "rank": "58", "id": "tt0169547" },
//            { "title": "The Green Mile", "rank": "59", "id": "tt0120689" },
//            { "title": "Gladiator", "rank": "60", "id": "tt0172495" },
//            { "title": "The Intouchables", "rank": "61", "id": "tt1675434" },
//            { "title": "WALL·E", "rank": "62", "id": "tt0910970" },
//            { "title": "The Lives of Others", "rank": "63", "id": "tt0405094" },
//            { "title": "Toy Story 3", "rank": "64", "id": "tt0435761" },
//            { "title": "The Great Dictator", "rank": "65", "id": "tt0032553" },
//            { "title": "The Prestige", "rank": "66", "id": "tt0482571" },
//            { "title": "A Clockwork Orange", "rank": "67", "id": "tt0066921" },
//            { "title": "Lawrence of Arabia", "rank": "68", "id": "tt0056172" },
//            { "title": "Amélie", "rank": "69", "id": "tt0211915" },
//            { "title": "To Kill a Mockingbird", "rank": "70", "id": "tt0056592" },
//            { "title": "Reservoir Dogs", "rank": "71", "id": "tt0105236" },
//            { "title": "Das Boot", "rank": "72", "id": "tt0082096" },
//            { "title": "The Lion King", "rank": "73", "id": "tt0110357" }
//        ]
//    }
//}
