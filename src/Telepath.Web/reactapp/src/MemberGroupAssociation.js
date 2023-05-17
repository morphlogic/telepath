import React, { Component } from 'react';
import Autocomplete from 'react-autocomplete';
import TextField from '@material-ui/core/TextField';

export default class MemberGroupAssociation extends Component {
    state = {
        selectedMemberId: '', selectedMemberName: '', selectedGroupId: '', selectedGroupName: '', dashboardData: {}, loading: true
    };

    updateSelectedMember(id) {
        if (id && this.state.dashboardData) {
            var selectedMember = this.state.dashboardData.members.find(element => {
                return element.memberId == id;
            });

            this.setState({ selectedMemberId: id, selectedMemberName: selectedMember.fullName });
        }
    }

    updateSelectedGroup(id) {
        if (id && this.state.dashboardData) {
            var selectedGroup = this.state.dashboardData.thinkGroups.find(element => {
                return element.thinkGroupId == id;
            });

            this.setState({ selectedGroupId: id, selectedGroupName: selectedGroup.name });
        }
    }

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
                                    value={this.state.selectedMemberName}
                                    items={this.state.dashboardData.members}
                                    getItemValue={item => item.memberId.toString()}
                                    getOptionLabel={item => item.fullName}
                                    getOptionSelected={item => item.memberId}
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
                                    renderInput={params => (
                                        <TextField {...params} label="Select a member" />
                                    )}
                                    onChange={(_event, val) => this.setState({ selectedMemberId: val })}
                                    onSelect={val => { this.updateSelectedMember(val); }}
                                />
                            </div>
                            <div className="autocomplete-wrapper">
                                <h3>Select a group for which to add this member:</h3>
                                <Autocomplete
                                    value={this.state.selectedGroupName}
                                    items={this.state.dashboardData.thinkGroups}
                                    getItemValue={item => item.thinkGroupId.toString()}
                                    getOptionSelected={item => item.thinkGroupId}
                                    getOptionLabel={item => item.name}
                                    shouldItemRender={item => item.name}
                                    renderMenu={item => (
                                        <div className="dropdown">
                                            {item}
                                        </div>
                                    )}
                                    renderItem={(item, isHighlighted) =>
                                        <div key={item.name} className={`item ${isHighlighted ? 'selected-item' : ''}`}>
                                            {item.name}
                                        </div>
                                    }
                                    renderInput={params => (
                                        <TextField {...params} label="Select a group" />
                                    )}
                                    onChange={(_event, val) => this.setState({ selectedGroupId: val })}
                                    onSelect={val => this.updateSelectedGroup(val)}
                                />
                            </div>
                            <button onClick={() => this.doSomething(this.state.selectedMemberId, this.state.selectedGroupId)}>GO</button>
                        </>
                }
            </>
        );
    }

    doSomething(memberId, thinkGroupId) {
        fetch('dashboard?' + new URLSearchParams({ memberId, thinkGroupId }), {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
        });
    }

    renderDashboard(dashboard) {

        console.log(dashboard);
    }
}