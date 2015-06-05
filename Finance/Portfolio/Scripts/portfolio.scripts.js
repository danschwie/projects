jQuery(function ($)
{
    // Check if namespace is defined
    if (typeof (Finance) === 'undefined')
    {
        Finance = {};
    }

    // Check if namespace is defined
    if (typeof (Finance.Portfolio) === 'undefined')
    {
        Finance.Portfolio = {};
    }

    // Define the application namespace
    Finance.Portfolio = (function ($)
    {
        var _init = function ()
        {
        };

        var _initPortfolioHistoryList = function (gridId, gridPagingId, gridContainerId, createActionUrl)
        {
            $('#' + gridId).jqGrid('setGridParam', {
                gridComplete: function ()
                {
                    var grid = $('#' + gridId);
                    var ids = grid.jqGrid('getDataIDs');
                    for (var i = 0; i < ids.length; i++)
                    {
                        var cl = ids[i];

                        grid.jqGrid('setRowData', ids[i]);
                    }
                },
                loadError: function (jqXHR, textStatus, errorThrown)
                {
                    _displayError(jqXHR, textStatus, errorThrown);
                }
            });

            initCreateButton(gridId, createActionUrl);
        };

        var displayError = function (jqXHR, textStatus, errorThrown)
        {
            // Convert html text response to jquery
            var responseText = jqXHR.responseText;
            var error = $(responseText);

            // Create message, parsing out important info from asp.net error message
            var message = '<p>Status: ' + errorThrown;
            message += '<br /><br />Details:<br />';
            message += error.find('h1:first').text() + '<br /><br />';
            message += error.find('h2:first').html() + '<br /><br />';
            message += '<code>' + error.find('code:first').html() + '</code></p>';

            // Open modal with current error
            $('#modal-error').find('.modal-body').html(message);
            $('#modal-error').modal('show');
        };

        function initCreateButton(gridId, createActionUrl)
        {
            var modalName = 'modal-create';

            $('.btn-primary').click(function (e)
            {
                e.preventDefault();
                $('#' + modalName).data('id', $(this).data('id')).modal('show');

                console.log($('#' + modalName).data('id', $(this).data('id')));
            });

            $('#' + modalName + ':not(.disabled)').on('show', function ()
            {
                var modal = $(this);
                $(this).load(createActionUrl, function (responseText, textStatus, XMLHttpRequest)
                {
                    if (textStatus == 'success')
                    {
                        $('.datepicker').datepicker({
                            showButtonPanel: true,
                            changeMonth: true,
                            changeYear: true
                        });
                        $.validator.unobtrusive.parse($('form'));
                        _initSelectList();
                        $(':input:visible:enabled:first', $(this).find('form')).focus();
                        $('form').submit(function ()
                        {
                            if ($(this).valid())
                            {
                                $.ajax({
                                    url: this.action,
                                    type: this.method,
                                    data: $(this).serialize(),
                                    success: function (data, textStatus, jqXHR)
                                    {
                                        if (data.success)
                                        {
                                            $('#' + gridId).trigger("reloadGrid");

                                            $('#message-success span').html(data.message);
                                            $('#message-success').show();
                                            modal.modal('hide');
                                            $('html, body').animate({ scrollTop: 0 }, 'slow');
                                        }
                                        else
                                        {
                                            if (data.modelStateError)
                                            {
                                                for (var i = 0; i < data.errorList.length; i++)
                                                {
                                                    var item = data.errorList[i];
                                                    var field = $('#' + item.key);

                                                    if (field.length)
                                                    {
                                                        field.parents('.control-group').addClass('error');
                                                        var errorMessage = $('<span>').text(item.errors.join(', '));
                                                        field.next('span').removeClass('field-validation-valid').addClass('field-validation-error').append(errorMessage);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                $('#message-error span').html(data.message);
                                                $('#message-error').show()
                                                modal.modal('hide');
                                                $('html, body').animate({ scrollTop: 0 }, 'slow');
                                            }
                                        }
                                    },
                                    error: function (jqXHR, textStatus, errorThrown)
                                    {
                                        modal.modal('hide');
                                        _displayError(jqXHR, textStatus, errorThrown);
                                    }
                                });
                            }
                            return false;
                        });
                    }
                });
            });

            $('#' + modalName).on('shown', function ()
            {
                $(':input:visible:enabled:first', $(this).find('form')).focus();
            });
        };

        return {
            init: function ()
            {
                _init();
            },
            initPortfolioHistoryList: function (gridId, gridPagingId, gridContainerId, createActionUrl)
            {
                _initPortfolioHistoryList(gridId, gridPagingId, gridContainerId, createActionUrl);
            }
        }
    })(jQuery);

    Finance.Portfolio.init();
});