import React, { Component } from 'react';

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };
    }

    componentDidMount() {
        this.populateWeatherData();
    }

    static renderForecastsTable(forecasts) {

        function handleClick() {
            alert('hi');

            fetch('dashboard')
                .then(function (response) {
                    var blah = response.json();
                    return blah;
                }).then(function (data) {
                    console.log(data);
                });
                //.then(response => response.json())
                //.then(json => console.log(json));

            //const response = await fetch('viewmodel');
            //const data = await response.json();
            //alert(data.ThinkGroups.count);
        }

        return (
            <table className='table table-striped' aria-labelledby="tabelLabel" onClick={handleClick} >
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Temp. (C)</th>
                        <th>Temp. (F)</th>
                        <th>Summary</th>
                    </tr>
                </thead>
                <tbody>
                    {forecasts.map(forecast =>
                        <tr key={forecast.date}>
                            <td>{forecast.date}</td>
                            <td>{forecast.temperatureC}</td>
                            <td>{forecast.temperatureF}</td>
                            <td>{forecast.summary}</td>
                        </tr>
                    )}
                </tbody>
            </table >
        );
    }

    static renderDashboard(dashboard) {

        console.log(dashboard);

        return (
            <ul>
                {dashboard.thinkGroups.map(item =>
                    <li>{item.name}</li>
                )}
            </ul>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
            : App.renderForecastsTable(this.state.forecasts);
        let dashboardView = this.state.loading
            ? <p><em>Loading dashboard...</em></p>
            : App.renderDashboard(this.state.dashboard);

        return (
            <div>
                <h1 id="tabelLabel" >Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
                {dashboardView}
            </div>
        );
    }

    async populateWeatherData() {
        const response = await fetch('weatherforecast');
        const data = await response.json();
        const dashResponse = await fetch('dashboard');
        const dashData = await dashResponse.json();            

        console.log(dashData);

        this.setState({ forecasts: data, dashboard: dashData, loading: false });
    }
}
